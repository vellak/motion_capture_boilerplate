using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.CoordinateMappingChangedEventArgs
    //
    public sealed class CoordinateMappingChangedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal CoordinateMappingChangedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_CoordinateMappingChangedEventArgs_AddRefObject(ref _pNative);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~CoordinateMappingChangedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMappingChangedEventArgs_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_CoordinateMappingChangedEventArgs_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<CoordinateMappingChangedEventArgs>(_pNative);
            Windows_Kinect_CoordinateMappingChangedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }

        private void __EventCleanup()
        {
        }
    }
}