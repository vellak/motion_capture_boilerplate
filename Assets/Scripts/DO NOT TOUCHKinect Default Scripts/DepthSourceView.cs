﻿using Windows.Kinect;
using UnityEngine;

public enum DepthViewMode
{
    SeparateSourceReaders,
    MultiSourceReader
}

public class DepthSourceView : MonoBehaviour
{
    // Only works at 4 right now
    private const int _DownsampleSize = 4;
    private const double _DepthScale = 0.1f;
    private const int _Speed = 50;
    private ColorSourceManager _ColorManager;
    private DepthSourceManager _DepthManager;
    private CoordinateMapper _Mapper;
    private Mesh _Mesh;

    private MultiSourceManager _MultiManager;

    private KinectSensor _Sensor;
    private int[] _Triangles;
    private Vector2[] _UV;
    private Vector3[] _Vertices;

    public GameObject ColorSourceManager;
    public GameObject DepthSourceManager;
    public GameObject MultiSourceManager;
    public DepthViewMode ViewMode = DepthViewMode.SeparateSourceReaders;

    private void Start()
    {
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Mapper = _Sensor.CoordinateMapper;
            var frameDesc = _Sensor.DepthFrameSource.FrameDescription;

            // Downsample to lower resolution
            CreateMesh(frameDesc.Width / _DownsampleSize, frameDesc.Height / _DownsampleSize);

            if (!_Sensor.IsOpen) _Sensor.Open();
        }
    }

    private void CreateMesh(int width, int height)
    {
        _Mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = _Mesh;

        _Vertices = new Vector3[width * height];
        _UV = new Vector2[width * height];
        _Triangles = new int[6 * (width - 1) * (height - 1)];

        var triangleIndex = 0;
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            var index = y * width + x;

            _Vertices[index] = new Vector3(x, -y, 0);
            _UV[index] = new Vector2(x / (float) width, y / (float) height);

            // Skip the last row/col
            if (x != width - 1 && y != height - 1)
            {
                var topLeft = index;
                var topRight = topLeft + 1;
                var bottomLeft = topLeft + width;
                var bottomRight = bottomLeft + 1;

                _Triangles[triangleIndex++] = topLeft;
                _Triangles[triangleIndex++] = topRight;
                _Triangles[triangleIndex++] = bottomLeft;
                _Triangles[triangleIndex++] = bottomLeft;
                _Triangles[triangleIndex++] = topRight;
                _Triangles[triangleIndex++] = bottomRight;
            }
        }

        _Mesh.vertices = _Vertices;
        _Mesh.uv = _UV;
        _Mesh.triangles = _Triangles;
        _Mesh.RecalculateNormals();
    }

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));
        GUI.TextField(new Rect(Screen.width - 250, 10, 250, 20), "DepthMode: " + ViewMode);
        GUI.EndGroup();
    }

    private void Update()
    {
        if (_Sensor == null) return;

        if (Input.GetButtonDown("Fire1"))
        {
            if (ViewMode == DepthViewMode.MultiSourceReader)
                ViewMode = DepthViewMode.SeparateSourceReaders;
            else
                ViewMode = DepthViewMode.MultiSourceReader;
        }

        var yVal = Input.GetAxis("Horizontal");
        var xVal = -Input.GetAxis("Vertical");

        transform.Rotate(
            xVal * Time.deltaTime * _Speed,
            yVal * Time.deltaTime * _Speed,
            0,
            Space.Self);

        if (ViewMode == DepthViewMode.SeparateSourceReaders)
        {
            if (ColorSourceManager == null) return;

            _ColorManager = ColorSourceManager.GetComponent<ColorSourceManager>();
            if (_ColorManager == null) return;

            if (DepthSourceManager == null) return;

            _DepthManager = DepthSourceManager.GetComponent<DepthSourceManager>();
            if (_DepthManager == null) return;

            gameObject.GetComponent<Renderer>().material.mainTexture = _ColorManager.GetColorTexture();
            RefreshData(_DepthManager.GetData(),
                _ColorManager.ColorWidth,
                _ColorManager.ColorHeight);
        }
        else
        {
            if (MultiSourceManager == null) return;

            _MultiManager = MultiSourceManager.GetComponent<MultiSourceManager>();
            if (_MultiManager == null) return;

            gameObject.GetComponent<Renderer>().material.mainTexture = _MultiManager.GetColorTexture();

            RefreshData(_MultiManager.GetDepthData(),
                _MultiManager.ColorWidth,
                _MultiManager.ColorHeight);
        }
    }

    private void RefreshData(ushort[] depthData, int colorWidth, int colorHeight)
    {
        var frameDesc = _Sensor.DepthFrameSource.FrameDescription;

        var colorSpace = new ColorSpacePoint[depthData.Length];
        _Mapper.MapDepthFrameToColorSpace(depthData, colorSpace);

        for (var y = 0; y < frameDesc.Height; y += _DownsampleSize)
        for (var x = 0; x < frameDesc.Width; x += _DownsampleSize)
        {
            var indexX = x / _DownsampleSize;
            var indexY = y / _DownsampleSize;
            var smallIndex = indexY * (frameDesc.Width / _DownsampleSize) + indexX;

            var avg = GetAvg(depthData, x, y, frameDesc.Width, frameDesc.Height);

            avg = avg * _DepthScale;

            _Vertices[smallIndex].z = (float) avg;

            // Update UV mapping with CDRP
            var colorSpacePoint = colorSpace[y * frameDesc.Width + x];
            _UV[smallIndex] = new Vector2(colorSpacePoint.X / colorWidth, colorSpacePoint.Y / colorHeight);
        }

        _Mesh.vertices = _Vertices;
        _Mesh.uv = _UV;
        _Mesh.triangles = _Triangles;
        _Mesh.RecalculateNormals();
    }

    private double GetAvg(ushort[] depthData, int x, int y, int width, int height)
    {
        var sum = 0.0;

        for (var y1 = y; y1 < y + 4; y1++)
        for (var x1 = x; x1 < x + 4; x1++)
        {
            var fullIndex = y1 * width + x1;

            if (depthData[fullIndex] == 0)
                sum += 4500;
            else
                sum += depthData[fullIndex];
        }

        return sum / 16;
    }

    private void OnApplicationQuit()
    {
        if (_Mapper != null) _Mapper = null;

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen) _Sensor.Close();

            _Sensor = null;
        }
    }
}