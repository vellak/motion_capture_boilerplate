using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.VisualGestureBuilderFrame
    //
    public sealed class VisualGestureBuilderFrame : RootSystem.IDisposable, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal VisualGestureBuilderFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_AddRefObject(ref _pNative);
        }

        public Dictionary<Gesture,
            ContinuousGestureResult> ContinuousGestureResults
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrame");

                var outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_ContinuousGestureResults_Length(
                        _pNative);
                var outKeys = new RootSystem.IntPtr[outCollectionSize];
                var outValues = new RootSystem.IntPtr[outCollectionSize];
                var managedDictionary =
                    new Dictionary<Gesture,
                        ContinuousGestureResult>();

                outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_ContinuousGestureResults(
                        _pNative, outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++)
                {
                    if (outKeys[i] == RootSystem.IntPtr.Zero || outValues[i] == RootSystem.IntPtr.Zero) continue;

                    var keyObj =
                        NativeObjectCache.CreateOrGetObject(
                            outKeys[i], n => new Gesture(n));

                    var valueObj =
                        NativeObjectCache
                            .CreateOrGetObject(
                                outValues[i],
                                n => new ContinuousGestureResult(n));

                    managedDictionary.Add(keyObj, valueObj);
                }

                return managedDictionary;
            }
        }

        public Dictionary<Gesture,
            DiscreteGestureResult> DiscreteGestureResults
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrame");

                var outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_DiscreteGestureResults_Length(
                        _pNative);
                var outKeys = new RootSystem.IntPtr[outCollectionSize];
                var outValues = new RootSystem.IntPtr[outCollectionSize];
                var managedDictionary =
                    new Dictionary<Gesture,
                        DiscreteGestureResult>();

                outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_DiscreteGestureResults(_pNative,
                        outKeys, outValues, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++)
                {
                    if (outKeys[i] == RootSystem.IntPtr.Zero || outValues[i] == RootSystem.IntPtr.Zero) continue;

                    var keyObj =
                        NativeObjectCache.CreateOrGetObject(
                            outKeys[i], n => new Gesture(n));

                    var valueObj =
                        NativeObjectCache
                            .CreateOrGetObject(
                                outValues[i], n => new DiscreteGestureResult(n));

                    managedDictionary.Add(keyObj, valueObj);
                }

                return managedDictionary;
            }
        }

        public bool IsTrackingIdValid
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrame");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_IsTrackingIdValid(_pNative);
            }
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrame");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_RelativeTime(_pNative));
            }
        }

        public ulong TrackingId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrame");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_TrackingId(_pNative);
            }
        }

        public VisualGestureBuilderFrameSource VisualGestureBuilderFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrame");

                var objectPointer =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_VisualGestureBuilderFrameSource(
                        _pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache
                    .CreateOrGetObject(
                        objectPointer,
                        n => new VisualGestureBuilderFrameSource(n));
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~VisualGestureBuilderFrame()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<VisualGestureBuilderFrame>(_pNative);

            if (disposing) Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_Dispose(_pNative);

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_ContinuousGestureResults(
                RootSystem.IntPtr pNative, [Out] RootSystem.IntPtr[] outKeys, [Out] RootSystem.IntPtr[] outValues,
                int outCollectionSize);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_ContinuousGestureResults_Length(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_DiscreteGestureResults(
                RootSystem.IntPtr pNative, [Out] RootSystem.IntPtr[] outKeys, [Out] RootSystem.IntPtr[] outValues,
                int outCollectionSize);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_DiscreteGestureResults_Length(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_IsTrackingIdValid(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_RelativeTime(
            RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern ulong Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_TrackingId(
            RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_get_VisualGestureBuilderFrameSource(
                RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrame_Dispose(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}