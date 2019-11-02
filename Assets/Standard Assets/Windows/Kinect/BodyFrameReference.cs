using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.BodyFrameReference
    //
    public sealed class BodyFrameReference : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal BodyFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyFrameReference_AddRefObject(ref _pNative);
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("BodyFrameReference");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_BodyFrameReference_get_RelativeTime(_pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~BodyFrameReference()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<BodyFrameReference>(_pNative);
            Windows_Kinect_BodyFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_BodyFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameReference_AcquireFrame(
            RootSystem.IntPtr pNative);

        public BodyFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameReference");

            var objectPointer = Windows_Kinect_BodyFrameReference_AcquireFrame(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new BodyFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }
}