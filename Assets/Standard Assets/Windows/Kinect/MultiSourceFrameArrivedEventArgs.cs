using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.MultiSourceFrameArrivedEventArgs
    //
    public sealed class MultiSourceFrameArrivedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal MultiSourceFrameArrivedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_MultiSourceFrameArrivedEventArgs_AddRefObject(ref _pNative);
        }

        public MultiSourceFrameReference FrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrameArrivedEventArgs");

                var objectPointer =
                    Windows_Kinect_MultiSourceFrameArrivedEventArgs_get_FrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(
                    objectPointer, n => new MultiSourceFrameReference(n));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~MultiSourceFrameArrivedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_MultiSourceFrameArrivedEventArgs_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_MultiSourceFrameArrivedEventArgs_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<MultiSourceFrameArrivedEventArgs>(_pNative);
            Windows_Kinect_MultiSourceFrameArrivedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameArrivedEventArgs_get_FrameReference(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}