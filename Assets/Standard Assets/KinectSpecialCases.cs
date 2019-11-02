using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PointF
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointF)) return false;

            return Equals((ColorSpacePoint) obj);
        }

        public bool Equals(ColorSpacePoint obj)
        {
            return X == obj.X && Y == obj.Y;
        }

        public static bool operator ==(PointF a, PointF b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(PointF a, PointF b)
        {
            return !a.Equals(b);
        }
    }

    public sealed partial class AudioBeamSubFrame
    {
        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToIntPtr(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, uint frameDataSize);

        public void CopyFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

            Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToIntPtr(_pNative, frameData, size);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamSubFrame_LockAudioBuffer(
            RootSystem.IntPtr pNative);

        public KinectBuffer LockAudioBuffer()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

            var objectPointer = Windows_Kinect_AudioBeamSubFrame_LockAudioBuffer(_pNative);
            ExceptionHelper.CheckLastError();

            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new KinectBuffer(n));
        }
    }

    public sealed partial class AudioBeamFrame
    {
        private AudioBeamSubFrame[] _subFrames;

        public IList<AudioBeamSubFrame> SubFrames
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamFrame");

                if (_subFrames == null)
                {
                    var collectionSize = Windows_Kinect_AudioBeamFrame_get_SubFrames_Length(_pNative);
                    var outCollection = new RootSystem.IntPtr[collectionSize];
                    _subFrames = new AudioBeamSubFrame[collectionSize];

                    collectionSize =
                        Windows_Kinect_AudioBeamFrame_get_SubFrames(_pNative, outCollection, collectionSize);
                    ExceptionHelper.CheckLastError();

                    for (var i = 0; i < collectionSize; i++)
                    {
                        if (outCollection[i] == RootSystem.IntPtr.Zero) continue;

                        var obj = NativeObjectCache
                            .GetObject<AudioBeamSubFrame>(outCollection[i]);
                        if (obj == null)
                        {
                            obj = new AudioBeamSubFrame(outCollection[i]);
                            NativeObjectCache.AddObject(outCollection[i], obj);
                        }

                        _subFrames[i] = obj;
                    }
                }

                return _subFrames;
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            if (_subFrames != null)
            {
                foreach (var subFrame in _subFrames) subFrame.Dispose();

                _subFrames = null;
            }

            __EventCleanup();

            NativeObjectCache.RemoveObject<AudioBeamFrame>(_pNative);
            Windows_Kinect_AudioBeamFrame_ReleaseObject(ref _pNative);

            if (disposing) Windows_Kinect_AudioBeamFrame_Dispose(_pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }

        [DllImport("KinectUnityAddin", CallingConvention =
            CallingConvention.Cdecl)]
        private static extern void Windows_Kinect_AudioBeamFrame_Dispose(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioBeamFrame_get_SubFrames(RootSystem.IntPtr pNative,
            [Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);

        [DllImport("KinectUnityAddin", CallingConvention =
            CallingConvention.Cdecl)]
        private static extern int Windows_Kinect_AudioBeamFrame_get_SubFrames_Length(RootSystem.IntPtr pNative);
    }

    public sealed partial class BodyFrame
    {
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrame_GetAndRefreshBodyData(RootSystem.IntPtr pNative,
            [Out] RootSystem.IntPtr[] bodies, int bodiesSize);

        public void GetAndRefreshBodyData(IList<Body> bodies)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrame");

            var _bodies_idx = 0;
            var _bodies = new RootSystem.IntPtr[bodies.Count];
            for (var i = 0; i < bodies.Count; i++)
            {
                if (bodies[i] == null) bodies[i] = new Body();

                _bodies[_bodies_idx] = bodies[i].GetIntPtr();
                _bodies_idx++;
            }

            Windows_Kinect_BodyFrame_GetAndRefreshBodyData(_pNative, _bodies, bodies.Count);
            ExceptionHelper.CheckLastError();

            for (var i = 0; i < bodies.Count; i++) bodies[i].SetIntPtr(_bodies[i]);
        }
    }

    public sealed partial class Body
    {
        internal Body()
        {
        }

        public PointF Lean
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Body");

                var objectPointer = Windows_Kinect_Body_get_Lean(_pNative);
                ExceptionHelper.CheckLastError();

                var obj = (PointF) Marshal.PtrToStructure(
                    objectPointer, typeof(PointF));
                Marshal.FreeHGlobal(objectPointer);
                return obj;
            }
        }

        internal void SetIntPtr(RootSystem.IntPtr value)
        {
            _pNative = value;
        }

        internal RootSystem.IntPtr GetIntPtr()
        {
            return _pNative;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_Body_get_Lean(RootSystem.IntPtr pNative);
    }

    public sealed partial class ColorFrame
    {
        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_ColorFrame_CopyRawFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_CopyRawFrameDataToIntPtr(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, uint frameDataSize);

        public void CopyRawFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

            Windows_Kinect_ColorFrame_CopyRawFrameDataToIntPtr(_pNative, frameData, size);
            ExceptionHelper.CheckLastError();
        }

        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_CopyConvertedFrameDataToIntPtr(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, uint frameDataSize, ColorImageFormat colorFormat);

        public void CopyConvertedFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size,
            ColorImageFormat colorFormat)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

            Windows_Kinect_ColorFrame_CopyConvertedFrameDataToIntPtr(_pNative, frameData, size, colorFormat);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_LockRawImageBuffer(RootSystem.IntPtr pNative);

        public KinectBuffer LockRawImageBuffer()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

            var objectPointer = Windows_Kinect_ColorFrame_LockRawImageBuffer(_pNative);
            ExceptionHelper.CheckLastError();

            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new KinectBuffer(n));
        }
    }

    public sealed partial class DepthFrame
    {
        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_DepthFrame_CopyFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_DepthFrame_CopyFrameDataToIntPtr(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, uint frameDataSize);

        public void CopyFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("DepthFrame");

            Windows_Kinect_DepthFrame_CopyFrameDataToIntPtr(_pNative, frameData, size / sizeof(ushort));
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_DepthFrame_LockImageBuffer(RootSystem.IntPtr pNative);

        public KinectBuffer LockImageBuffer()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("DepthFrame");

            var objectPointer = Windows_Kinect_DepthFrame_LockImageBuffer(_pNative);
            ExceptionHelper.CheckLastError();

            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new KinectBuffer(n));
        }
    }

    public sealed partial class BodyIndexFrame
    {
        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_BodyIndexFrame_CopyFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrame_CopyFrameDataToIntPtr(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, uint frameDataSize);

        public void CopyFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyIndexFrame");

            Windows_Kinect_BodyIndexFrame_CopyFrameDataToIntPtr(_pNative, frameData, size);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Windows_Kinect_BodyIndexFrame_LockImageBuffer(RootSystem.IntPtr pNative);

        public KinectBuffer LockImageBuffer()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyIndexFrame");

            var objectPointer = Windows_Kinect_BodyIndexFrame_LockImageBuffer(_pNative);
            ExceptionHelper.CheckLastError();

            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new KinectBuffer(n));
        }
    }

    public sealed partial class InfraredFrame
    {
        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_InfraredFrame_CopyFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_InfraredFrame_CopyFrameDataToIntPtr(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, uint frameDataSize);

        public void CopyFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("InfraredFrame");

            Windows_Kinect_InfraredFrame_CopyFrameDataToIntPtr(_pNative, frameData, size / sizeof(ushort));
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrame_LockImageBuffer(RootSystem.IntPtr pNative);

        public KinectBuffer LockImageBuffer()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("InfraredFrame");

            var objectPointer = Windows_Kinect_InfraredFrame_LockImageBuffer(_pNative);
            ExceptionHelper.CheckLastError();

            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new KinectBuffer(n));
        }
    }

    public sealed partial class KinectSensor
    {
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            if (IsOpen) Close();

            __EventCleanup();

            NativeObjectCache.RemoveObject<KinectSensor>(_pNative);
            Windows_Kinect_KinectSensor_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }
    }

    public sealed partial class LongExposureInfraredFrame
    {
        [DllImport(
            "KinectUnityAddin",
            EntryPoint = "Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToArray",
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToIntPtr(
            RootSystem.IntPtr pNative, RootSystem.IntPtr frameData, uint frameDataSize);

        public void CopyFrameDataToIntPtr(RootSystem.IntPtr frameData, uint size)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");

            Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToIntPtr(_pNative, frameData, size / sizeof(ushort));
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrame_LockImageBuffer(
            RootSystem.IntPtr pNative);

        public KinectBuffer LockImageBuffer()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");

            var objectPointer = Windows_Kinect_LongExposureInfraredFrame_LockImageBuffer(_pNative);
            ExceptionHelper.CheckLastError();

            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new KinectBuffer(n));
        }
    }

    public sealed partial class CoordinateMapper
    {
        private PointF[] _DepthFrameToCameraSpaceTable;

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_GetDepthCameraIntrinsics(
            RootSystem.IntPtr pNative);

        public CameraIntrinsics GetDepthCameraIntrinsics()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var objectPointer = Windows_Kinect_CoordinateMapper_GetDepthCameraIntrinsics(_pNative);
            ExceptionHelper.CheckLastError();

            var obj = (CameraIntrinsics) Marshal.PtrToStructure(
                objectPointer, typeof(CameraIntrinsics));
            Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_CoordinateMapper_GetDepthFrameToCameraSpaceTable(
            RootSystem.IntPtr pNative, RootSystem.IntPtr outCollection, uint outCollectionSize);

        public PointF[] GetDepthFrameToCameraSpaceTable()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            if (_DepthFrameToCameraSpaceTable == null)
            {
                var desc = KinectSensor.GetDefault().DepthFrameSource.FrameDescription;
                _DepthFrameToCameraSpaceTable = new PointF[desc.Width * desc.Height];

                var pointsSmartGCHandle = new SmartGCHandle(
                    GCHandle.Alloc(_DepthFrameToCameraSpaceTable,
                        GCHandleType.Pinned));
                var _points = pointsSmartGCHandle.AddrOfPinnedObject();
                Windows_Kinect_CoordinateMapper_GetDepthFrameToCameraSpaceTable(_pNative, _points,
                    (uint) _DepthFrameToCameraSpaceTable.Length);
                ExceptionHelper.CheckLastError();
            }

            return _DepthFrameToCameraSpaceTable;
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(
            RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData,
            uint depthFrameDataSize,
            RootSystem.IntPtr depthSpacePoints,
            uint depthSpacePointsSize);

        public void MapColorFrameToDepthSpaceUsingIntPtr(RootSystem.IntPtr depthFrameData, uint depthFrameSize,
            RootSystem.IntPtr depthSpacePoints, uint depthSpacePointsSize)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var length = depthFrameSize / sizeof(ushort);
            Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(_pNative, depthFrameData, length,
                depthSpacePoints, depthSpacePointsSize);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(
            RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData,
            uint depthFrameDataSize,
            RootSystem.IntPtr cameraSpacePoints,
            uint cameraSpacePointsSize);

        public void MapColorFrameToCameraSpaceUsingIntPtr(RootSystem.IntPtr depthFrameData, int depthFrameSize,
            RootSystem.IntPtr cameraSpacePoints, uint cameraSpacePointsSize)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var length = (uint) depthFrameSize / sizeof(ushort);
            Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(_pNative, depthFrameData, length,
                cameraSpacePoints, cameraSpacePointsSize);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(
            RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData,
            uint depthFrameDataSize,
            RootSystem.IntPtr colorSpacePoints,
            uint colorSpacePointsSize);

        public void MapDepthFrameToColorSpaceUsingIntPtr(RootSystem.IntPtr depthFrameData, int depthFrameSize,
            RootSystem.IntPtr colorSpacePoints, uint colorSpacePointsSize)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var length = (uint) depthFrameSize / sizeof(ushort);
            Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(_pNative, depthFrameData, length,
                colorSpacePoints, colorSpacePointsSize);
            ExceptionHelper.CheckLastError();
        }


        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(
            RootSystem.IntPtr pNative,
            RootSystem.IntPtr depthFrameData,
            uint depthFrameDataSize,
            RootSystem.IntPtr cameraSpacePoints,
            uint cameraSpacePointsSize);

        public void MapDepthFrameToCameraSpaceUsingIntPtr(RootSystem.IntPtr depthFrameData, int depthFrameSize,
            RootSystem.IntPtr cameraSpacePoints, uint cameraSpacePointsSize)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("CoordinateMapper");

            var length = (uint) depthFrameSize / sizeof(ushort);
            Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(_pNative, depthFrameData, length,
                cameraSpacePoints, cameraSpacePointsSize);
            ExceptionHelper.CheckLastError();
        }
    }
}