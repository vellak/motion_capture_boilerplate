using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.VisualGestureBuilderFrameArrivedEventArgs
    //
    public sealed class VisualGestureBuilderFrameArrivedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal VisualGestureBuilderFrameArrivedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_AddRefObject(ref _pNative);
        }

        public VisualGestureBuilderFrameReference FrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameArrivedEventArgs");

                var objectPointer =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_get_FrameReference(
                        _pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache
                    .CreateOrGetObject(
                        objectPointer,
                        n => new VisualGestureBuilderFrameReference(n));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~VisualGestureBuilderFrameArrivedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_ReleaseObject(
                ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_AddRefObject(
                ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<VisualGestureBuilderFrameArrivedEventArgs>(_pNative);
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_get_FrameReference(
                RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}