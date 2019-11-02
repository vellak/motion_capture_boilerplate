using Windows.Kinect;
using UnityEngine;

public class ColorSourceManager : MonoBehaviour
{
    private byte[] _Data;
    private ColorFrameReader _Reader;

    private KinectSensor _Sensor;
    private Texture2D _Texture;
    public int ColorWidth { get; private set; }
    public int ColorHeight { get; private set; }

    public Texture2D GetColorTexture()
    {
        return _Texture;
    }

    private void Start()
    {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.ColorFrameSource.OpenReader();

            var frameDesc = _Sensor.ColorFrameSource.CreateFrameDescription(ColorImageFormat.Rgba);
            ColorWidth = frameDesc.Width;
            ColorHeight = frameDesc.Height;

            _Texture = new Texture2D(frameDesc.Width, frameDesc.Height, TextureFormat.RGBA32, false);
            _Data = new byte[frameDesc.BytesPerPixel * frameDesc.LengthInPixels];

            if (!_Sensor.IsOpen) _Sensor.Open();
        }
    }

    private void Update()
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();

            if (frame != null)
            {
                frame.CopyConvertedFrameDataToArray(_Data, ColorImageFormat.Rgba);
                _Texture.LoadRawTextureData(_Data);
                _Texture.Apply();

                frame.Dispose();
                frame = null;
            }
        }
    }

    private void OnApplicationQuit()
    {
        if (_Reader != null)
        {
            _Reader.Dispose();
            _Reader = null;
        }

        if (_Sensor != null)
        {
            if (_Sensor.IsOpen) _Sensor.Close();

            _Sensor = null;
        }
    }
}