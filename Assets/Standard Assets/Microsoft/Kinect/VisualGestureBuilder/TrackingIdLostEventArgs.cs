using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.TrackingIdLostEventArgs
    //
    public sealed class TrackingIdLostEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal TrackingIdLostEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_AddRefObject(ref _pNative);
        }

        public ulong TrackingId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("TrackingIdLostEventArgs");

                return Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_get_TrackingId(_pNative);
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~TrackingIdLostEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<TrackingIdLostEventArgs>(_pNative);
            Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern ulong Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_get_TrackingId(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}