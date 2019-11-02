using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Data;
using AOT;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioSource
    //
    public sealed class AudioSource : INativeWrapper

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
        internal AudioSource(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioSource_AddRefObject(ref _pNative);
        }

        public IList<AudioBeam> AudioBeams
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                var outCollectionSize = Windows_Kinect_AudioSource_get_AudioBeams_Length(_pNative);
                var outCollection = new RootSystem.IntPtr[outCollectionSize];
                var managedCollection = new AudioBeam[outCollectionSize];

                outCollectionSize =
                    Windows_Kinect_AudioSource_get_AudioBeams(_pNative, outCollection, outCollectionSize);
                ExceptionHelper.CheckLastError();
                for (var i = 0; i < outCollectionSize; i++)
                {
                    if (outCollection[i] == RootSystem.IntPtr.Zero) continue;

                    var obj = NativeObjectCache.CreateOrGetObject(outCollection[i],
                        n => new AudioBeam(n));

                    managedCollection[i] = obj;
                }

                return managedCollection;
            }
        }

        public bool IsActive
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                return Windows_Kinect_AudioSource_get_IsActive(_pNative);
            }
        }

        public KinectSensor KinectSensor
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                var objectPointer = Windows_Kinect_AudioSource_get_KinectSensor(_pNative);
                ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero) return null;

                return NativeObjectCache.CreateOrGetObject(objectPointer,
                    n => new KinectSensor(n));
            }
        }

        public uint MaxSubFrameCount
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                return Windows_Kinect_AudioSource_get_MaxSubFrameCount(_pNative);
            }
        }

        public RootSystem.TimeSpan SubFrameDuration
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioSource_get_SubFrameDuration(_pNative));
            }
        }

        public uint SubFrameLengthInBytes
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                return Windows_Kinect_AudioSource_get_SubFrameLengthInBytes(_pNative);
            }
        }

        public KinectAudioCalibrationState AudioCalibrationState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

                return Windows_Kinect_AudioSource_get_AudioCalibrationState(_pNative);
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~AudioSource()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioSource_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioSource_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<AudioSource>(_pNative);
            Windows_Kinect_AudioSource_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioSource_get_AudioBeams(RootSystem.IntPtr pNative,
            [Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioSource_get_AudioBeams_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern bool Windows_Kinect_AudioSource_get_IsActive(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioSource_get_KinectSensor(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Kinect_AudioSource_get_MaxSubFrameCount(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_AudioSource_get_SubFrameDuration(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Kinect_AudioSource_get_SubFrameLengthInBytes(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern KinectAudioCalibrationState
            Windows_Kinect_AudioSource_get_AudioCalibrationState(RootSystem.IntPtr pNative);

        [MonoPInvokeCallback(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
        private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result,
            RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<FrameCapturedEventArgs>> callbackList = null;
            Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock (callbackList)
            {
                var objThis = NativeObjectCache.GetObject<AudioSource>(pNative);
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
        private static extern void Windows_Kinect_AudioSource_add_FrameCaptured(RootSystem.IntPtr pNative,
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
                        Windows_Kinect_AudioSource_add_FrameCaptured(_pNative, del, false);
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
                        Windows_Kinect_AudioSource_add_FrameCaptured(_pNative,
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
                var objThis = NativeObjectCache.GetObject<AudioSource>(pNative);
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
        private static extern void Windows_Kinect_AudioSource_add_PropertyChanged(RootSystem.IntPtr pNative,
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
                        Windows_Kinect_AudioSource_add_PropertyChanged(_pNative, del, false);
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
                        Windows_Kinect_AudioSource_add_PropertyChanged(_pNative,
                            Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioSource_OpenReader(RootSystem.IntPtr pNative);

        public AudioBeamFrameReader OpenReader()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("AudioSource");

            var objectPointer = Windows_Kinect_AudioSource_OpenReader(_pNative);
            ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero) return null;

            return NativeObjectCache.CreateOrGetObject(objectPointer,
                n => new AudioBeamFrameReader(n));
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
                            Windows_Kinect_AudioSource_add_FrameCaptured(_pNative,
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
                            Windows_Kinect_AudioSource_add_PropertyChanged(_pNative,
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