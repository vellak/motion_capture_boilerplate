using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.BodyIndexFrame
    //
    public sealed partial class BodyIndexFrame : RootSystem.IDisposable, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal BodyIndexFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyIndexFrame_AddRefObject(ref _pNative);
        }

        public BodyIndexFrameSource BodyIndexFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyIndexFrame");

                var objectPointer = Windows_Kinect_BodyIndexFrame_get_BodyIndexFrameSource(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new BodyIndexFrameSource(n));
            }
        }

        public FrameDescription FrameDescription
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyIndexFrame");

                var objectPointer = Windows_Kinect_BodyIndexFrame_get_FrameDescription(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new FrameDescription(n));
            }
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyIndexFrame");

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_BodyIndexFrame_get_RelativeTime(_pNative));
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~BodyIndexFrame()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrame_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrame_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<BodyIndexFrame>(_pNative);

            if (disposing) Windows_Kinect_BodyIndexFrame_Dispose(_pNative);

            Windows_Kinect_BodyIndexFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrame_get_BodyIndexFrameSource(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrame_get_FrameDescription(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_BodyIndexFrame_get_RelativeTime(RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, int frameDataSize);

        public void CopyFrameDataToArray(byte[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyIndexFrame");

            var frameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(frameData,
                    GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_BodyIndexFrame_CopyFrameDataToArray(_pNative, _frameData, frameData.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrame_Dispose(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}