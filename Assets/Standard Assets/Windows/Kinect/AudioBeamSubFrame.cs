using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamSubFrame
    //
    public sealed partial class AudioBeamSubFrame : RootSystem.IDisposable, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal AudioBeamSubFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamSubFrame_AddRefObject(ref _pNative);
        }

        public AudioBeamMode AudioBeamMode
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                return Windows_Kinect_AudioBeamSubFrame_get_AudioBeamMode(_pNative);
            }
        }

        public IList<AudioBodyCorrelation> AudioBodyCorrelations
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                var outCollectionSize = Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations_Length(_pNative);
                var outCollection = new RootSystem.IntPtr[outCollectionSize];
                var managedCollection = new AudioBodyCorrelation[outCollectionSize];

                outCollectionSize =
                    Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations(_pNative, outCollection,
                        outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++)
                {
                    if (outCollection[i] == RootSystem.IntPtr.Zero) continue;

                    var obj = NativeObjectCache.CreateOrGetObject(
                        outCollection[i], n => new AudioBodyCorrelation(n));

                    managedCollection[i] = obj;
                }

                return managedCollection;
            }
        }

        public float BeamAngle
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                return Windows_Kinect_AudioBeamSubFrame_get_BeamAngle(_pNative);
            }
        }

        public float BeamAngleConfidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                return Windows_Kinect_AudioBeamSubFrame_get_BeamAngleConfidence(_pNative);
            }
        }

        public RootSystem.TimeSpan Duration
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamSubFrame_get_Duration(_pNative));
            }
        }

        public uint FrameLengthInBytes
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                return Windows_Kinect_AudioBeamSubFrame_get_FrameLengthInBytes(_pNative);
            }
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_AudioBeamSubFrame_get_RelativeTime(_pNative));
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~AudioBeamSubFrame()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<AudioBeamSubFrame>(_pNative);

            if (disposing) Windows_Kinect_AudioBeamSubFrame_Dispose(_pNative);

            Windows_Kinect_AudioBeamSubFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern AudioBeamMode Windows_Kinect_AudioBeamSubFrame_get_AudioBeamMode(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations(RootSystem.IntPtr pNative,
            [Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations_Length(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern float Windows_Kinect_AudioBeamSubFrame_get_BeamAngle(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern float Windows_Kinect_AudioBeamSubFrame_get_BeamAngleConfidence(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_AudioBeamSubFrame_get_Duration(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Kinect_AudioBeamSubFrame_get_FrameLengthInBytes(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_AudioBeamSubFrame_get_RelativeTime(RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, int frameDataSize);

        public void CopyFrameDataToArray(byte[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");

            var frameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(frameData,
                    GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray(_pNative, _frameData, frameData.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_Dispose(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}