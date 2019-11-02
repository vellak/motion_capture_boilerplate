using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.InfraredFrameReference
    //
    public sealed class InfraredFrameReference : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal InfraredFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_InfraredFrameReference_AddRefObject(ref _pNative);
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("InfraredFrameReference");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_InfraredFrameReference_get_RelativeTime(_pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~InfraredFrameReference()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_InfraredFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_InfraredFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<InfraredFrameReference>(_pNative);
            Windows_Kinect_InfraredFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_InfraredFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameReference_AcquireFrame(
            RootSystem.IntPtr pNative);

        public InfraredFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("InfraredFrameReference");

            var objectPointer = Windows_Kinect_InfraredFrameReference_AcquireFrame(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new InfraredFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }
}