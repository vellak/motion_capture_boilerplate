using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorFrame
    //
    public sealed partial class ColorFrame : RootSystem.IDisposable, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal ColorFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_ColorFrame_AddRefObject(ref _pNative);
        }

        public ColorCameraSettings ColorCameraSettings
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

                var objectPointer = Windows_Kinect_ColorFrame_get_ColorCameraSettings(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new ColorCameraSettings(n));
            }
        }

        public ColorFrameSource ColorFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

                var objectPointer = Windows_Kinect_ColorFrame_get_ColorFrameSource(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new ColorFrameSource(n));
            }
        }

        public FrameDescription FrameDescription
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

                var objectPointer = Windows_Kinect_ColorFrame_get_FrameDescription(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new FrameDescription(n));
            }
        }

        public ColorImageFormat RawColorImageFormat
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

                return Windows_Kinect_ColorFrame_get_RawColorImageFormat(_pNative);
            }
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_ColorFrame_get_RelativeTime(_pNative));
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~ColorFrame()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<ColorFrame>(_pNative);

            if (disposing) Windows_Kinect_ColorFrame_Dispose(_pNative);

            Windows_Kinect_ColorFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_ColorCameraSettings(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_ColorFrameSource(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_FrameDescription(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern ColorImageFormat Windows_Kinect_ColorFrame_get_RawColorImageFormat(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_ColorFrame_get_RelativeTime(RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_CopyRawFrameDataToArray(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, int frameDataSize);

        public void CopyRawFrameDataToArray(byte[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

            var frameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(frameData,
                    GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_ColorFrame_CopyRawFrameDataToArray(_pNative, _frameData, frameData.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray(RootSystem.IntPtr pNative,
            RootSystem.IntPtr frameData, int frameDataSize, ColorImageFormat colorFormat);

        public void CopyConvertedFrameDataToArray(byte[] frameData, ColorImageFormat colorFormat)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

            var frameDataSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(frameData,
                    GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray(_pNative, _frameData, frameData.Length,
                colorFormat);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_CreateFrameDescription(
            RootSystem.IntPtr pNative, ColorImageFormat format);

        public FrameDescription CreateFrameDescription(ColorImageFormat format)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("ColorFrame");

            var objectPointer = Windows_Kinect_ColorFrame_CreateFrameDescription(_pNative, format);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new FrameDescription(n));
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorFrame_Dispose(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}