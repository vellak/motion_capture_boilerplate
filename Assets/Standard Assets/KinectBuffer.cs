using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Kinect
{
    // NOTE: This uses an IBuffer under the covers, it is renamed here to give parity to our managed APIs.
    public class KinectBuffer : INativeWrapper, RootSystem.IDisposable
    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal KinectBuffer(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Storage_Streams_IBuffer_AddRefObject(ref _pNative);
        }

        public uint Capacity
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("KinectBuffer");

                var capacity = Windows_Storage_Streams_IBuffer_get_Capacity(_pNative);
                ExceptionHelper.CheckLastError();
                return capacity;
            }
        }

        public uint Length
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("KinectBuffer");

                var length = Windows_Storage_Streams_IBuffer_get_Length(_pNative);
                ExceptionHelper.CheckLastError();
                return length;
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("KinectBuffer");

                Windows_Storage_Streams_IBuffer_put_Length(_pNative, value);
                ExceptionHelper.CheckLastError();
            }
        }

        public RootSystem.IntPtr UnderlyingBuffer
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("KinectBuffer");

                var value = Windows_Storage_Streams_IBuffer_get_UnderlyingBuffer(_pNative);
                ExceptionHelper.CheckLastError();
                return value;
            }
        }

        // Constructors and Finalizers
        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero) throw new RootSystem.ObjectDisposedException("KinectBuffer");

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~KinectBuffer()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin", CallingConvention =
            CallingConvention.Cdecl)]
        private static extern void Windows_Storage_Streams_IBuffer_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin", CallingConvention =
            CallingConvention.Cdecl)]
        private static extern void Windows_Storage_Streams_IBuffer_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            NativeObjectCache.RemoveObject<KinectBuffer>(_pNative);

            if (disposing) Windows_Storage_Streams_IBuffer_Dispose(_pNative);

            Windows_Storage_Streams_IBuffer_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Storage_Streams_IBuffer_get_Capacity(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Storage_Streams_IBuffer_get_Length(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Storage_Streams_IBuffer_put_Length(RootSystem.IntPtr pNative, uint value);

        [DllImport("KinectUnityAddin", CallingConvention =
            CallingConvention.Cdecl)]
        private static extern void Windows_Storage_Streams_IBuffer_Dispose(RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Storage_Streams_IBuffer_get_UnderlyingBuffer(
            RootSystem.IntPtr pNative);
    }
}