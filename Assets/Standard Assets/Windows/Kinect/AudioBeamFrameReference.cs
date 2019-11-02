using System.Collections.Generic;
using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamFrameReference
    //
    public sealed class AudioBeamFrameReference : INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal AudioBeamFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamFrameReference_AddRefObject(ref _pNative);
        }

        public RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrameReference");

                return RootSystem.TimeSpan.FromMilliseconds(
                    Windows_Kinect_AudioBeamFrameReference_get_RelativeTime(_pNative));
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~AudioBeamFrameReference()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Kinect_AudioBeamFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<AudioBeamFrameReference>(_pNative);
            Windows_Kinect_AudioBeamFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern long Windows_Kinect_AudioBeamFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);


        // Public Methods
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames_Length(
            RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames(RootSystem.IntPtr pNative,
            [Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);

        public IList<AudioBeamFrame> AcquireBeamFrames()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
                throw new RootSystem.ObjectDisposedException("AudioBeamFrameReference");

            var outCollectionSize = Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames_Length(_pNative);
            var outCollection = new RootSystem.IntPtr[outCollectionSize];
            var managedCollection = new AudioBeamFrame[outCollectionSize];

            outCollectionSize =
                Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames(_pNative, outCollection, outCollectionSize);
            ExceptionHelper.CheckLastError();
            for (var i = 0; i < outCollectionSize; i++)
            {
                if (outCollection[i] == RootSystem.IntPtr.Zero) continue;

                var obj = NativeObjectCache.CreateOrGetObject(outCollection[i],
                    n => new AudioBeamFrame(n));

                managedCollection[i] = obj;
            }

            return managedCollection;
        }

        private void __EventCleanup()
        {
        }
    }
}