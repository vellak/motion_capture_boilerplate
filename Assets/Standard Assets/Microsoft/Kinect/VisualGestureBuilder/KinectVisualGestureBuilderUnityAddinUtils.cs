using System.Runtime.InteropServices;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.KinectVisualGestureBuilderUnityAddinUtils
    //
    public sealed class KinectVisualGestureBuilderUnityAddinUtils
    {
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void KinectVisualGestureBuilderUnityAddin_FreeMemory(RootSystem.IntPtr pToDealloc);

        public static void FreeMemory(RootSystem.IntPtr pToDealloc)
        {
            KinectVisualGestureBuilderUnityAddin_FreeMemory(pToDealloc);
        }
    }
}