using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Data;
using AOT;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.VisualGestureBuilderFrameReader
    //
    public sealed class VisualGestureBuilderFrameReader : RootSystem.IDisposable, INativeWrapper

    {
        // Events
        private static GCHandle
            _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<
                VisualGestureBuilderFrameArrivedEventArgs>>>
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks =
                new CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<
                    VisualGestureBuilderFrameArrivedEventArgs>>>();

        private static GCHandle
            _Windows_Data_PropertyChangedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<PropertyChangedEventArgs>>
        > Windows_Data_PropertyChangedEventArgs_Delegate_callbacks =
            new CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<PropertyChangedEventArgs>>>();

        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal VisualGestureBuilderFrameReader(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_AddRefObject(ref _pNative);
        }

        public bool IsPaused
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameReader");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_get_IsPaused(_pNative);
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameReader");

                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_put_IsPaused(_pNative, value);
                ExceptionHelper.CheckLastError();
            }
        }

        public VisualGestureBuilderFrameSource VisualGestureBuilderFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameReader");

                var objectPointer =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_get_VisualGestureBuilderFrameSource(
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

        ~VisualGestureBuilderFrameReader()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<VisualGestureBuilderFrameReader>(_pNative);

            if (disposing) Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_Dispose(_pNative);

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_get_IsPaused(
            RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_put_IsPaused(
            RootSystem.IntPtr pNative, bool isPaused);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_get_VisualGestureBuilderFrameSource(
                RootSystem.IntPtr pNative);

        [MonoPInvokeCallback(
            typeof(_Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate))]
        private static void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handler(
                RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<VisualGestureBuilderFrameArrivedEventArgs
            >> callbackList = null;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks
                .TryGetValue(pNative, out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<VisualGestureBuilderFrameReader>(pNative);
                var args = new VisualGestureBuilderFrameArrivedEventArgs(result);
                foreach (var func in callbackList)
                    EventPump.Instance.Enqueue(() =>
                    {
                        try
                        {
                            func(objThis, args);
                        }
                        catch
                        {
                        }
                    });
            }
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_FrameArrived(
                RootSystem.IntPtr pNative,
                _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate eventCallback,
                bool unsubscribe);

        public event RootSystem.EventHandler<VisualGestureBuilderFrameArrivedEventArgs>
            FrameArrived
            {
                add
                {
                    EventPump.EnsureInitialized();

                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks
                        .TryAddDefault(_pNative);
                    var callbackList =
                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks
                            [_pNative];
                    lock (callbackList)
                    {
                        callbackList.Add(value);
                        if (callbackList.Count == 1)
                        {
                            var del =
                                new
                                    _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate(
                                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handler);
                            _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handle
                                = GCHandle.Alloc(del);
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_FrameArrived(
                                _pNative, del, false);
                        }
                    }
                }
                remove
                {
                    if (_pNative == RootSystem.IntPtr.Zero) return;

                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks
                        .TryAddDefault(_pNative);
                    var callbackList =
                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks
                            [_pNative];
                    lock (callbackList)
                    {
                        callbackList.Remove(value);
                        if (callbackList.Count == 0)
                        {
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_FrameArrived(
                                _pNative,
                                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handler,
                                true);
                            _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handle
                                .Free();
                        }
                    }
                }
            }

        [MonoPInvokeCallback(typeof(_Windows_Data_PropertyChangedEventArgs_Delegate))]
        private static void Windows_Data_PropertyChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result,
            RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<PropertyChangedEventArgs>> callbackList = null;
            Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<VisualGestureBuilderFrameReader>(pNative);
                var args = new PropertyChangedEventArgs(result);
                foreach (var func in callbackList)
                    EventPump.Instance.Enqueue(() =>
                    {
                        try
                        {
                            func(objThis, args);
                        }
                        catch
                        {
                        }
                    });
            }
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_PropertyChanged(
                RootSystem.IntPtr pNative, _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback,
                bool unsubscribe);

        public event RootSystem.EventHandler<PropertyChangedEventArgs> PropertyChanged
        {
            add
            {
                EventPump.EnsureInitialized();

                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if (callbackList.Count == 1)
                    {
                        var del = new _Windows_Data_PropertyChangedEventArgs_Delegate(
                            Windows_Data_PropertyChangedEventArgs_Delegate_Handler);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle =
                            GCHandle.Alloc(del);
                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_PropertyChanged(
                            _pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero) return;

                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if (callbackList.Count == 0)
                    {
                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_PropertyChanged(
                            _pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_CalculateAndAcquireLatestFrame(
                RootSystem.IntPtr pNative);

        public VisualGestureBuilderFrame CalculateAndAcquireLatestFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameReader");

            var objectPointer =
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_CalculateAndAcquireLatestFrame(
                    _pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache
                .CreateOrGetObject(objectPointer,
                    n => new VisualGestureBuilderFrame(n));
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_Dispose(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
            {
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks
                    .TryAddDefault(_pNative);
                var callbackList =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_callbacks[
                        _pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_FrameArrived(
                                _pNative,
                                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handler,
                                true);

                        _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate_Handle
                            .Free();
                    }
                }
            }
            {
                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameReader_add_PropertyChanged(
                                _pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);

                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameArrivedEventArgs_Delegate(
            RootSystem.IntPtr args, RootSystem.IntPtr pNative);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Data_PropertyChangedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);
    }
}