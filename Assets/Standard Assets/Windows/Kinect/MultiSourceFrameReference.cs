using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.MultiSourceFrameReference
    //
    public sealed class MultiSourceFrameReference : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal MultiSourceFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_MultiSourceFrameReference_AddRefObject(ref _pNative);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~MultiSourceFrameReference()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Windows_Kinect_MultiSourceFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_MultiSourceFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<MultiSourceFrameReference>(_pNative);
            Windows_Kinect_MultiSourceFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameReference_AcquireFrame(
            RootSystem.IntPtr pNative);

        public MultiSourceFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("MultiSourceFrameReference");

            var objectPointer = Windows_Kinect_MultiSourceFrameReference_AcquireFrame(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new MultiSourceFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }
}