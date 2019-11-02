using Windows.Kinect;
using UnityEngine;

public class InfraredSourceManager : MonoBehaviour
{
    private ushort[] _Data;
    private byte[] _RawData;
    private InfraredFrameReader _Reader;
    private KinectSensor _Sensor;

    // I'm not sure this makes sense for the Kinect APIs
    // Instead, this logic should be in the VIEW
    private Texture2D _Texture;

    public Texture2D GetInfraredTexture()
    {
        return _Texture;
    }

    private void Start()
    {
        _Sensor = KinectSensor.GetDefault();
        if (_Sensor != null)
        {
            _Reader = _Sensor.InfraredFrameSource.OpenReader();
            var frameDesc = _Sensor.InfraredFrameSource.FrameDescription;
            _Data = new ushort[frameDesc.LengthInPixels];
            _RawData = new byte[frameDesc.LengthInPixels * 4];
            _Texture = new Texture2D(frameDesc.Width, frameDesc.Height, TextureFormat.BGRA32, false);

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
                frame.CopyFrameDataToArray(_Data);

                var index = 0;
                foreach (var ir in _Data)
                {
                    var intensity = (byte) (ir >> 8);
                    _RawData[index++] = intensity;
                    _RawData[index++] = intensity;
                    _RawData[index++] = intensity;
                    _RawData[index++] = 255; // Alpha
                }

                _Texture.LoadRawTextureData(_RawData);
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