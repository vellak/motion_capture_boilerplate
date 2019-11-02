using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.Gesture
    //
    public sealed class Gesture : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal Gesture(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_Gesture_AddRefObject(ref _pNative);
        }

        public GestureType GestureType
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Gesture");

                return Microsoft_Kinect_VisualGestureBuilder_Gesture_get_GestureType(_pNative);
            }
        }

        public string Name
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("Gesture");

                var objectPointer = Microsoft_Kinect_VisualGestureBuilder_Gesture_get_Name(_pNative);
                ExceptionHelper.CheckLastError();

                var managedString = Marshal.PtrToStringUni(objectPointer);
                Marshal.FreeCoTaskMem(objectPointer);
                return managedString;
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~Gesture()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_Gesture_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_Gesture_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<Gesture>(_pNative);
            Microsoft_Kinect_VisualGestureBuilder_Gesture_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern GestureType
            Microsoft_Kinect_VisualGestureBuilder_Gesture_get_GestureType(RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Microsoft_Kinect_VisualGestureBuilder_Gesture_get_Name(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}