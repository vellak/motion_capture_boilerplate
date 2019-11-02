using System.Runtime.InteropServices;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.KinectUnityAddinUtils
    //
    public sealed class KinectUnityAddinUtils
    {
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void KinectUnityAddin_FreeMemory(RootSystem.IntPtr pToDealloc);

        public static void FreeMemory(RootSystem.IntPtr pToDealloc)
        {
            KinectUnityAddin_FreeMemory(pToDealloc);
        }
    }
}