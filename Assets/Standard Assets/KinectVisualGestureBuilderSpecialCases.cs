using System.Runtime.InteropServices;
using Windows.Kinect;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    public sealed partial class VisualGestureBuilderDatabase
    {
        [DllImport(
            "KinectVisualGestureBuilderUnityAddin",
            EntryPoint = "Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_ctor",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern RootSystem.IntPtr Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_ctor(
            [MarshalAs(UnmanagedType.LPWStr)] string path);

        public static VisualGestureBuilderDatabase Create(string path)
        {
            var objectPointer =
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_ctor(path);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache
                .CreateOrGetObject(
                    objectPointer, n => new VisualGestureBuilderDatabase(n));
        }
    }

    public sealed partial class VisualGestureBuilderFrameSource
    {
        [DllImport(
            "KinectVisualGestureBuilderUnityAddin",
            EntryPoint = "Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_ctor",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_ctor(RootSystem.IntPtr sensorPtr,
                ulong initialTrackingId);

        public static VisualGestureBuilderFrameSource Create(KinectSensor sensor,
            ulong initialTrackingId)
        {
            var objectPointer =
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_ctor(
                    NativeWrapper.GetNativePtr(sensor), initialTrackingId);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache
                .CreateOrGetObject(
                    objectPointer, n => new VisualGestureBuilderFrameSource(n));
        }

        [DllImport(
            "KinectVisualGestureBuilderUnityAddin",
            EntryPoint = "Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_GetIsEnabled",
            CallingConvention = CallingConvention.Cdecl)]
        private static extern bool Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_GetIsEnabled(
            RootSystem.IntPtr pNative, RootSystem.IntPtr gesturePtr);

        public bool GetIsEnabled(Gesture gesture)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

            var result =
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_GetIsEnabled(_pNative,
                    NativeWrapper.GetNativePtr(gesture));
            ExceptionHelper.CheckLastError();
            return result;
        }
    }
}