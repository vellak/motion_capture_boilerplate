using System;

namespace Helper
{
    public static class NativeWrapper
    {
        public static IntPtr GetNativePtr(object obj)
        {
            if (obj == null) return IntPtr.Zero;

            var nativeWrapperIface = obj as INativeWrapper;
            if (nativeWrapperIface != null)
                return nativeWrapperIface.nativePtr;
            throw new ArgumentException("Object must wrap native type");
        }
    }
}