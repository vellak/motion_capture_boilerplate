using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.LongExposureInfraredFrameReference
    //
    public sealed class LongExposureInfraredFrameReference : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal LongExposureInfraredFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_LongExposureInfraredFrameReference_AddRefObject(ref _pNative);
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReference");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_LongExposureInfraredFrameReference_get_RelativeTime(_pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~LongExposureInfraredFrameReference()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrameReference_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrameReference_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<LongExposureInfraredFrameReference>(_pNative);
            Windows_Kinect_LongExposureInfraredFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_LongExposureInfraredFrameReference_get_RelativeTime(
            RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameReference_AcquireFrame(
            RootSystem.IntPtr pNative);

        public LongExposureInfraredFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReference");

            var objectPointer = Windows_Kinect_LongExposureInfraredFrameReference_AcquireFrame(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new LongExposureInfraredFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }
}