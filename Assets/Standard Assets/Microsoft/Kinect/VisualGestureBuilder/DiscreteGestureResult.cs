using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.DiscreteGestureResult
    //
    public sealed class DiscreteGestureResult : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal DiscreteGestureResult(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_AddRefObject(ref _pNative);
        }

        public float Confidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("DiscreteGestureResult");

                return Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_get_Confidence(_pNative);
            }
        }

        public bool Detected
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("DiscreteGestureResult");

                return Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_get_Detected(_pNative);
            }
        }

        public bool FirstFrameDetected
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("DiscreteGestureResult");

                return Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_get_FirstFrameDetected(_pNative);
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~DiscreteGestureResult()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<DiscreteGestureResult>(_pNative);
            Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern float Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_get_Confidence(
            RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_get_Detected(
            RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Microsoft_Kinect_VisualGestureBuilder_DiscreteGestureResult_get_FirstFrameDetected(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}