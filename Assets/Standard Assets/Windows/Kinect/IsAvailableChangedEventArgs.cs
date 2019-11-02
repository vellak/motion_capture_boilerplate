using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.IsAvailableChangedEventArgs
    //
    public sealed class IsAvailableChangedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal IsAvailableChangedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_IsAvailableChangedEventArgs_AddRefObject(ref _pNative);
        }

        public bool IsAvailable
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("IsAvailableChangedEventArgs");

                return Windows_Kinect_IsAvailableChangedEventArgs_get_IsAvailable(_pNative);
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~IsAvailableChangedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_IsAvailableChangedEventArgs_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_IsAvailableChangedEventArgs_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<IsAvailableChangedEventArgs>(_pNative);
            Windows_Kinect_IsAvailableChangedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool
            Windows_Kinect_IsAvailableChangedEventArgs_get_IsAvailable(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}