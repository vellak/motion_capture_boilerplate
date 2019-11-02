using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.FrameCapturedEventArgs
    //
    public sealed class FrameCapturedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal FrameCapturedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_FrameCapturedEventArgs_AddRefObject(ref _pNative);
        }

        public FrameCapturedStatus FrameStatus
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");

                return Windows_Kinect_FrameCapturedEventArgs_get_FrameStatus(_pNative);
            }
        }

        public FrameSourceTypes FrameType
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");

                return Windows_Kinect_FrameCapturedEventArgs_get_FrameType(_pNative);
            }
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("FrameCapturedEventArgs");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_FrameCapturedEventArgs_get_RelativeTime(_pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~FrameCapturedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_FrameCapturedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_FrameCapturedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<FrameCapturedEventArgs>(_pNative);
            Windows_Kinect_FrameCapturedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern FrameCapturedStatus Windows_Kinect_FrameCapturedEventArgs_get_FrameStatus(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern FrameSourceTypes Windows_Kinect_FrameCapturedEventArgs_get_FrameType(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_FrameCapturedEventArgs_get_RelativeTime(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}