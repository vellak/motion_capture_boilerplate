using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.VisualGestureBuilderDatabase
    //
    public sealed partial class VisualGestureBuilderDatabase : RootSystem.IDisposable, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal VisualGestureBuilderDatabase(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_AddRefObject(ref _pNative);
        }

        public IList<Gesture> AvailableGestures
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderDatabase");

                var outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_get_AvailableGestures_Length(
                        _pNative);
                var outCollection = new RootSystem.IntPtr[outCollectionSize];
                var managedCollection = new Gesture[outCollectionSize];

                outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_get_AvailableGestures(_pNative,
                        outCollection, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++)
                {
                    if (outCollection[i] == RootSystem.IntPtr.Zero) continue;

                    var obj = NativeObjectCache.CreateOrGetObject(
                        outCollection[i], n => new Gesture(n));

                    managedCollection[i] = obj;
                }

                return managedCollection;
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~VisualGestureBuilderDatabase()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<VisualGestureBuilderDatabase>(_pNative);

            if (disposing) Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_Dispose(_pNative);

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_get_AvailableGestures(
                RootSystem.IntPtr pNative, [Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_get_AvailableGestures_Length(
                RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderDatabase_Dispose(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}