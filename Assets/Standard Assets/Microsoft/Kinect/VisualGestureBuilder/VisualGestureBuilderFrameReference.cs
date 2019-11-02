using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.VisualGestureBuilderFrameReference
    //
    public sealed class VisualGestureBuilderFrameReference : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal VisualGestureBuilderFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_AddRefObject(ref _pNative);
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameReference");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_get_RelativeTime(
                        _pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~VisualGestureBuilderFrameReference()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_ReleaseObject(
                ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_AddRefObject(
                ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<VisualGestureBuilderFrameReference>(_pNative);
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_get_RelativeTime(
                RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_AcquireFrame(
                RootSystem.IntPtr pNative);

        public VisualGestureBuilderFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameReference");

            var objectPointer =
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReference_AcquireFrame(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache
                .CreateOrGetObject(objectPointer,
                    n => new VisualGestureBuilderFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }
}