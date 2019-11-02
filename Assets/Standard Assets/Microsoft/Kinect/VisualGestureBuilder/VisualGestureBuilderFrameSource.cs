using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Windows.Data;
using Windows.Kinect;
using AOT;
using Helper;
using RootSystem = System;

namespace Microsoft.Kinect.VisualGestureBuilder
{
    //
    // Microsoft.Kinect.VisualGestureBuilder.VisualGestureBuilderFrameSource
    //
    public sealed partial class VisualGestureBuilderFrameSource : RootSystem.IDisposable, INativeWrapper

    {
        // Events
        private static GCHandle
            _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<
                TrackingIdLostEventArgs>>>
            Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks =
                new CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<
                    TrackingIdLostEventArgs>>>();

        private static GCHandle
            _Windows_Data_PropertyChangedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<PropertyChangedEventArgs>>
        > Windows_Data_PropertyChangedEventArgs_Delegate_callbacks =
            new CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<PropertyChangedEventArgs>>>();

        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal VisualGestureBuilderFrameSource(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_AddRefObject(ref _pNative);
        }

        public ulong TrackingId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_TrackingId(_pNative);
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_put_TrackingId(_pNative, value);
                ExceptionHelper.CheckLastError();
            }
        }

        public bool HorizontalMirror
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_HorizontalMirror(
                    _pNative);
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_put_HorizontalMirror(_pNative,
                    value);
                ExceptionHelper.CheckLastError();
            }
        }

        public IList<Gesture> Gestures
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                var outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_Gestures_Length(_pNative);
                var outCollection = new RootSystem.IntPtr[outCollectionSize];
                var managedCollection = new Gesture[outCollectionSize];

                outCollectionSize =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_Gestures(_pNative,
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

        public bool IsActive
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_IsActive(_pNative);
            }
        }

        public bool IsTrackingIdValid
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                return Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_IsTrackingIdValid(
                    _pNative);
            }
        }

        public KinectSensor KinectSensor
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

                var objectPointer =
                    Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_KinectSensor(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new KinectSensor(n));
            }
        }

        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~VisualGestureBuilderFrameSource()
        {
            Dispose(false);
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_ReleaseObject(
            ref RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_AddRefObject(
            ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<VisualGestureBuilderFrameSource>(_pNative);

            if (disposing) Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_Dispose(_pNative);

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern ulong
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_TrackingId(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_put_TrackingId(
            RootSystem.IntPtr pNative, ulong trackingId);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_HorizontalMirror(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_put_HorizontalMirror(
                RootSystem.IntPtr pNative, bool horizontalMirror);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_Gestures(
            RootSystem.IntPtr pNative, [Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_Gestures_Length(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_IsActive(
            RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_IsTrackingIdValid(
                RootSystem.IntPtr pNative);

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_get_KinectSensor(
                RootSystem.IntPtr pNative);

        [MonoPInvokeCallback(
            typeof(_Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate))]
        private static void Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handler(
            RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<TrackingIdLostEventArgs>> callbackList =
                null;
            Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks.TryGetValue(pNative,
                out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<VisualGestureBuilderFrameSource>(pNative);
                var args = new TrackingIdLostEventArgs(result);
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
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_TrackingIdLost(
                RootSystem.IntPtr pNative,
                _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate eventCallback,
                bool unsubscribe);

        public event RootSystem.EventHandler<TrackingIdLostEventArgs>
            TrackingIdLost
            {
                add
                {
                    EventPump.EnsureInitialized();

                    Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks.TryAddDefault(
                        _pNative);
                    var callbackList =
                        Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks[_pNative];
                    lock (callbackList)
                    {
                        callbackList.Add(value);
                        if (callbackList.Count == 1)
                        {
                            var del = new _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate(
                                Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handler);
                            _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handle =
                                GCHandle.Alloc(del);
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_TrackingIdLost(
                                _pNative, del, false);
                        }
                    }
                }
                remove
                {
                    if (_pNative == RootSystem.IntPtr.Zero) return;

                    Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks.TryAddDefault(
                        _pNative);
                    var callbackList =
                        Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks[_pNative];
                    lock (callbackList)
                    {
                        callbackList.Remove(value);
                        if (callbackList.Count == 0)
                        {
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_TrackingIdLost(
                                _pNative,
                                Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handler, true);
                            _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handle.Free();
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
                var objThis = NativeObjectCache.GetObject<VisualGestureBuilderFrameSource>(pNative);
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
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_PropertyChanged(
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
                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_PropertyChanged(
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
                        Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_PropertyChanged(
                            _pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_AddGesture(
            RootSystem.IntPtr pNative, RootSystem.IntPtr gesture);

        public void AddGesture(Gesture gesture)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_AddGesture(_pNative,
                NativeWrapper.GetNativePtr(gesture));
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_AddGestures(
            RootSystem.IntPtr pNative, RootSystem.IntPtr gestures, int gesturesSize);

        public void AddGestures(Gesture[] gestures)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

            var _gestures_idx = 0;
            var _gestures_array = new RootSystem.IntPtr[gestures.Count()];
            foreach (var value in gestures)
            {
                _gestures_array[_gestures_idx] = NativeWrapper.GetNativePtr(value);
                _gestures_idx++;
            }

            var gesturesSmartGCHandle = new SmartGCHandle(
                GCHandle.Alloc(_gestures_array,
                    GCHandleType.Pinned));
            var _gestures = gesturesSmartGCHandle.AddrOfPinnedObject();
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_AddGestures(_pNative, _gestures,
                gestures.Length);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_RemoveGesture(
            RootSystem.IntPtr pNative, RootSystem.IntPtr gesture);

        public void RemoveGesture(Gesture gesture)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_RemoveGesture(_pNative,
                NativeWrapper.GetNativePtr(gesture));
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_SetIsEnabled(
            RootSystem.IntPtr pNative, RootSystem.IntPtr gesture, bool isEnabled);

        public void SetIsEnabled(Gesture gesture, bool isEnabled)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_SetIsEnabled(_pNative,
                NativeWrapper.GetNativePtr(gesture), isEnabled);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr
            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_OpenReader(RootSystem.IntPtr pNative);

        public VisualGestureBuilderFrameReader OpenReader()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("VisualGestureBuilderFrameSource");

            var objectPointer =
                Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_OpenReader(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache
                .CreateOrGetObject(objectPointer,
                    n => new VisualGestureBuilderFrameReader(n));
        }

        [DllImport("KinectVisualGestureBuilderUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_Dispose(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
            {
                Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks
                    .TryAddDefault(_pNative);
                var callbackList =
                    Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_TrackingIdLost(
                                _pNative,
                                Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handler, true);

                        _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate_Handle.Free();
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
                            Microsoft_Kinect_VisualGestureBuilder_VisualGestureBuilderFrameSource_add_PropertyChanged(
                                _pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);

                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Microsoft_Kinect_VisualGestureBuilder_TrackingIdLostEventArgs_Delegate(
            RootSystem.IntPtr args, RootSystem.IntPtr pNative);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Data_PropertyChangedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);
    }
}