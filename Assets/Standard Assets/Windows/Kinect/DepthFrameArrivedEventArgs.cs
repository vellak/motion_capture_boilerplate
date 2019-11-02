using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.DepthFrameArrivedEventArgs
    //
    public sealed class DepthFrameArrivedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal DepthFrameArrivedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_DepthFrameArrivedEventArgs_AddRefObject(ref _pNative);
        }

        public DepthFrameReference FrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("DepthFrameArrivedEventArgs");

                var objectPointer =
                    Windows_Kinect_DepthFrameArrivedEventArgs_get_FrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new DepthFrameReference(n));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~DepthFrameArrivedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_DepthFrameArrivedEventArgs_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Windows_Kinect_DepthFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<DepthFrameArrivedEventArgs>(_pNative);
            Windows_Kinect_DepthFrameArrivedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameArrivedEventArgs_get_FrameReference(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}