using Windows.Kinect;
using UnityEngine;

public class BodySourceManager : MonoBehaviour
{
    private Body[] _Data;
    private BodyFrameReader _Reader;
    private KinectSensor _Sensor;

    public Body[] GetData()
    {
        return _Data;
    }


    private void Start()
    {
        _Sensor = KinectSensor.GetDefault();

        if (_Sensor != null)
        {
            _Reader = _Sensor.BodyFrameSource.OpenReader();

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
                if (_Data == null) _Data = new Body[_Sensor.BodyFrameSource.BodyCount];

                frame.GetAndRefreshBodyData(_Data);

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