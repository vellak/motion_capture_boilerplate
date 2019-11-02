using System.Runtime.InteropServices;
using Helper;
using RootSystem = System;

namespace Windows.Data
{
    //
    // Windows.Data.PropertyChangedEventArgs
    //
    public sealed class PropertyChangedEventArgs : RootSystem.EventArgs, INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;

        // Constructors and Finalizers
        internal PropertyChangedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Data_PropertyChangedEventArgs_AddRefObject(ref _pNative);
        }

        public string PropertyName
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                    throw new RootSystem.ObjectDisposedException("PropertyChangedEventArgs");

                var objectPointer = Windows_Data_PropertyChangedEventArgs_get_PropertyName(_pNative);
                ExceptionHelper.CheckLastError();

                var managedString = Marshal.PtrToStringUni(objectPointer);
                Marshal.FreeCoTaskMem(objectPointer);
                return managedString;
            }
        }

        RootSystem.IntPtr INativeWrapper.nativePtr => _pNative;

        ~PropertyChangedEventArgs()
        {
            Dispose(false);
        }

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Data_PropertyChangedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);

        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Data_PropertyChangedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);

        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero) return;

            __EventCleanup();

            NativeObjectCache.RemoveObject<PropertyChangedEventArgs>(_pNative);
            Windows_Data_PropertyChangedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [DllImport("KinectUnityAddin",
            CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Data_PropertyChangedEventArgs_get_PropertyName(
            RootSystem.IntPtr pNative);

        private void __EventCleanup()
        {
        }
    }
}