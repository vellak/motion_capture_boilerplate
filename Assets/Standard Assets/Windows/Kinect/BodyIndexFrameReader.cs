using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Data;
using AOT;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.BodyIndexFrameReader
    //
    public sealed class BodyIndexFrameReader : RootSystem.IDisposable, INativeWrapper

    {
        // Events
        private static GCHandle
            _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<BodyIndexFrameArrivedEventArgs>>>
            Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks =
                new CollectionMap<RootSystem.IntPtr,
                    List<RootSystem.EventHandler<BodyIndexFrameArrivedEventArgs>>>();

        private static GCHandle
            _Windows_Data_PropertyChangedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<PropertyChangedEventArgs>>
        > Windows_Data_PropertyChangedEventArgs_Delegate_callbacks =
            new CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<PropertyChangedEventArgs>>>();

        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal BodyIndexFrameReader(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyIndexFrameReader_AddRefObject(ref _pNative);
        }

        public BodyIndexFrameSource BodyIndexFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");

                var objectPointer =
                    Windows_Kinect_BodyIndexFrameReader_get_BodyIndexFrameSource(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new BodyIndexFrameSource(n));
            }
        }

        public bool IsPaused
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");

                return Windows_Kinect_BodyIndexFrameReader_get_IsPaused(_pNative);
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");

                Windows_Kinect_BodyIndexFrameReader_put_IsPaused(_pNative, value);
                ExceptionHelper.CheckLastError();
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~BodyIndexFrameReader()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<BodyIndexFrameReader>(_pNative);

            if (disposing) Windows_Kinect_BodyIndexFrameReader_Dispose(_pNative);

            Windows_Kinect_BodyIndexFrameReader_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameReader_get_BodyIndexFrameSource(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Windows_Kinect_BodyIndexFrameReader_get_IsPaused(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrameReader_put_IsPaused(RootSystem.IntPtr pNative,
            bool isPaused);

        [MonoPInvokeCallback(typeof(_Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate))]
        private static void Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result,
            RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<BodyIndexFrameArrivedEventArgs>> callbackList = null;
            Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<BodyIndexFrameReader>(pNative);
                var args = new BodyIndexFrameArrivedEventArgs(result);
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

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(RootSystem.IntPtr pNative,
            _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);

        public event RootSystem.EventHandler<BodyIndexFrameArrivedEventArgs> FrameArrived
        {
            add
            {
                EventPump.EnsureInitialized();

                Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if (callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate(
                            Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler);
                        _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handle =
                            GCHandle.Alloc(del);
                        Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero) return;

                Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if (callbackList.Count == 0)
                    {
                        Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(_pNative,
                            Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handle.Free();
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
                var objThis = NativeObjectCache.GetObject<BodyIndexFrameReader>(pNative);
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

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrameReader_add_PropertyChanged(RootSystem.IntPtr pNative,
            _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback, bool unsubscribe);

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
                        Windows_Kinect_BodyIndexFrameReader_add_PropertyChanged(_pNative, del, false);
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
                        Windows_Kinect_BodyIndexFrameReader_add_PropertyChanged(_pNative,
                            Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyIndexFrameReader_AcquireLatestFrame(
            RootSystem.IntPtr pNative);

        public BodyIndexFrame AcquireLatestFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("BodyIndexFrameReader");

            var objectPointer = Windows_Kinect_BodyIndexFrameReader_AcquireLatestFrame(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new BodyIndexFrame(n));
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyIndexFrameReader_Dispose(RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
            {
                Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                            Windows_Kinect_BodyIndexFrameReader_add_FrameArrived(_pNative,
                                Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handler, true);

                        _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate_Handle.Free();
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
                            Windows_Kinect_BodyIndexFrameReader_add_PropertyChanged(_pNative,
                                Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);

                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_BodyIndexFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Data_PropertyChangedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);
    }
}