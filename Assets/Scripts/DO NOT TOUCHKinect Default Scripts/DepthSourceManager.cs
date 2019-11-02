using Windows.Kinect;
using UnityEngine;

public class DepthSourceManager : MonoBehaviour
{
    private ushort[] _Data;
    private DepthFrameReader _Reader;
    private KinectSensor _Sensor;

    public ushort[] GetData()
    {
        return _Data;
    }

    private void Start()
    {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.DepthFrameSource.OpenReader();
            _Data = new ushort[_Sensor.DepthFrameSource.FrameDescription.LengthInPixels];
        }
    }

    private void Update()
    {
        if (_Reader != null)
        {
            var frame = _Reader.AcquireLatestFrame();
            if (frame != null)
            {
                frame.CopyFrameDataToArray(_Data);
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