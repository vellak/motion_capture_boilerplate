using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamFrame
    //
    public sealed partial class AudioBeamFrame : RootSystem.IDisposable, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal AudioBeamFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamFrame_AddRefObject(ref _pNative);
        }

        public AudioBeam AudioBeam
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamFrame");

                var objectPointer = Windows_Kinect_AudioBeamFrame_get_AudioBeam(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new AudioBeam(n));
            }
        }

        public AudioSource AudioSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamFrame");

                var objectPointer = Windows_Kinect_AudioBeamFrame_get_AudioSource(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new AudioSource(n));
            }
        }

        public RootSystem.TimeSpan Duration
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamFrame");

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamFrame_get_Duration(_pNative));
            }
        }

        public RootSystem.TimeSpan RelativeTimeStart
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioBeamFrame");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_AudioBeamFrame_get_RelativeTimeStart(_pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~AudioBeamFrame()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamFrame_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamFrame_AddRefObject(ref RootSystem.IntPtr pNative);

        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrame_get_AudioBeam(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Windows_Kinect_AudioBeamFrame_get_AudioSource(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_AudioBeamFrame_get_Duration(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_AudioBeamFrame_get_RelativeTimeStart(RootSystem.IntPtr pNative);


        // Public Methods
        private void __EventCleanup()
        {
        }
    }
}