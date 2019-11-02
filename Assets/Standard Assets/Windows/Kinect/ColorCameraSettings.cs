using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorCameraSettings
    //
    public sealed class ColorCameraSettings : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal ColorCameraSettings(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_ColorCameraSettings_AddRefObject(ref _pNative);
        }

        public RootSystem.TimeSpan ExposureTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_ColorCameraSettings_get_ExposureTime(_pNative));
            }
        }

        public RootSystem.TimeSpan FrameInterval
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_ColorCameraSettings_get_FrameInterval(_pNative));
            }
        }

        public float Gain
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");

                return Windows_Kinect_ColorCameraSettings_get_Gain(_pNative);
            }
        }

        public float Gamma
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");

                return Windows_Kinect_ColorCameraSettings_get_Gamma(_pNative);
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~ColorCameraSettings()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorCameraSettings_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_ColorCameraSettings_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<ColorCameraSettings>(_pNative);
            Windows_Kinect_ColorCameraSettings_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_ColorCameraSettings_get_ExposureTime(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_ColorCameraSettings_get_FrameInterval(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern float Windows_Kinect_ColorCameraSettings_get_Gain(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern float Windows_Kinect_ColorCameraSettings_get_Gamma(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}