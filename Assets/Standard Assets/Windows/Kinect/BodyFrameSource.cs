using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Data;
using AOT;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.BodyFrameSource
    //
    public sealed class BodyFrameSource : INativeWrapper

    {
        // Events
        private static GCHandle
            _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<FrameCapturedEventArgs>>
        > Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks =
            new CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<FrameCapturedEventArgs>>>();

        private static GCHandle
            _Windows_Data_PropertyChangedEventArgs_Delegate_Handle;

        private static readonly CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<PropertyChangedEventArgs>>
        > Windows_Data_PropertyChangedEventArgs_Delegate_callbacks =
            new CollectionMap<RootSystem.IntPtr,
                List<RootSystem.EventHandler<PropertyChangedEventArgs>>>();

        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal BodyFrameSource(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyFrameSource_AddRefObject(ref _pNative);
        }

        public int BodyCount
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameSource");

                return Windows_Kinect_BodyFrameSource_get_BodyCount(_pNative);
            }
        }

        public bool IsActive
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameSource");

                return Windows_Kinect_BodyFrameSource_get_IsActive(_pNative);
            }
        }

        public KinectSensor KinectSensor
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameSource");

                var objectPointer = Windows_Kinect_BodyFrameSource_get_KinectSensor(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new KinectSensor(n));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~BodyFrameSource()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrameSource_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrameSource_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<BodyFrameSource>(_pNative);
            Windows_Kinect_BodyFrameSource_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_BodyFrameSource_get_BodyCount(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Windows_Kinect_BodyFrameSource_get_IsActive(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameSource_get_KinectSensor(
            RootSystem.IntPtr pNative);

        [MonoPInvokeCallback(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
        private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result,
            RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<FrameCapturedEventArgs>> callbackList = null;
            Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<BodyFrameSource>(pNative);
                var args = new FrameCapturedEventArgs(result);
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
        private static extern void Windows_Kinect_BodyFrameSource_add_FrameCaptured(RootSystem.IntPtr pNative,
            _Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);

        public event RootSystem.EventHandler<FrameCapturedEventArgs> FrameCaptured
        {
            add
            {
                EventPump.EnsureInitialized();

                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if (callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_FrameCapturedEventArgs_Delegate(
                            Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler);
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle =
                            GCHandle.Alloc(del);
                        Windows_Kinect_BodyFrameSource_add_FrameCaptured(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero) return;

                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if (callbackList.Count == 0)
                    {
                        Windows_Kinect_BodyFrameSource_add_FrameCaptured(_pNative,
                            Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle.Free();
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
                var objThis = NativeObjectCache.GetObject<BodyFrameSource>(pNative);
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
        private static extern void Windows_Kinect_BodyFrameSource_add_PropertyChanged(RootSystem.IntPtr pNative,
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
                        Windows_Kinect_BodyFrameSource_add_PropertyChanged(_pNative, del, false);
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
                        Windows_Kinect_BodyFrameSource_add_PropertyChanged(_pNative,
                            Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameSource_OpenReader(RootSystem.IntPtr pNative);

        public BodyFrameReader OpenReader()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameSource");

            var objectPointer = Windows_Kinect_BodyFrameSource_OpenReader(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new BodyFrameReader(n));
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrameSource_OverrideHandTracking(RootSystem.IntPtr pNative,
            ulong trackingId);

        public void OverrideHandTracking(ulong trackingId)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameSource");

            Windows_Kinect_BodyFrameSource_OverrideHandTracking(_pNative, trackingId);
            ExceptionHelper.CheckLastError();
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_BodyFrameSource_OverrideHandTracking_1(RootSystem.IntPtr pNative,
            ulong oldTrackingId, ulong newTrackingId);

        public void OverrideHandTracking(ulong oldTrackingId, ulong newTrackingId)
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("BodyFrameSource");

            Windows_Kinect_BodyFrameSource_OverrideHandTracking_1(_pNative, oldTrackingId, newTrackingId);
            ExceptionHelper.CheckLastError();
        }

        private void __EventCleanup()
        {
            {
                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                            Windows_Kinect_BodyFrameSource_add_FrameCaptured(_pNative,
                                Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);

                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle.Free();
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
                            Windows_Kinect_BodyFrameSource_add_PropertyChanged(_pNative,
                                Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);

                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _Windows_Data_PropertyChangedEventArgs_Delegate(RootSystem.IntPtr args,
            RootSystem.IntPtr pNative);
    }
}