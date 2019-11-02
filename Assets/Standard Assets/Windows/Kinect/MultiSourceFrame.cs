using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.MultiSourceFrame
    //
    public sealed class MultiSourceFrame : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal MultiSourceFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_MultiSourceFrame_AddRefObject(ref _pNative);
        }

        public BodyFrameReference BodyFrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrame");

                var objectPointer = Windows_Kinect_MultiSourceFrame_get_BodyFrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new BodyFrameReference(n));
            }
        }

        public BodyIndexFrameReference BodyIndexFrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrame");

                var objectPointer = Windows_Kinect_MultiSourceFrame_get_BodyIndexFrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new BodyIndexFrameReference(n));
            }
        }

        public ColorFrameReference ColorFrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrame");

                var objectPointer = Windows_Kinect_MultiSourceFrame_get_ColorFrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new ColorFrameReference(n));
            }
        }

        public DepthFrameReference DepthFrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrame");

                var objectPointer = Windows_Kinect_MultiSourceFrame_get_DepthFrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new DepthFrameReference(n));
            }
        }

        public InfraredFrameReference InfraredFrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrame");

                var objectPointer = Windows_Kinect_MultiSourceFrame_get_InfraredFrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new InfraredFrameReference(n));
            }
        }

        public LongExposureInfraredFrameReference LongExposureInfraredFrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrame");

                var objectPointer =
                    Windows_Kinect_MultiSourceFrame_get_LongExposureInfraredFrameReference(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(
                    objectPointer, n => new LongExposureInfraredFrameReference(n));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~MultiSourceFrame()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_MultiSourceFrame_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_MultiSourceFrame_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<MultiSourceFrame>(_pNative);
            Windows_Kinect_MultiSourceFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_BodyFrameReference(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_BodyIndexFrameReference(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_ColorFrameReference(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_DepthFrameReference(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_InfraredFrameReference(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrame_get_LongExposureInfraredFrameReference(
            RootSystem.IntPtr pNative);


        // Public Methods
        private void __EventCleanup()
        {
        }
    }
}