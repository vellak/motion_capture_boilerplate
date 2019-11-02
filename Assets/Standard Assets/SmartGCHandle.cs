using System;
using System.Runtime.InteropServices;

namespace Helper
{
    public class SmartGCHandle : IDisposable
    {
        private GCHandle handle;

        public SmartGCHandle(GCHandle handle)
        {
            this.handle = handle;
        }

        public virtual void Dispose()
        {
            Dispose(true);
        }

        ~SmartGCHandle()
        {
            Dispose(false);
        }

        public IntPtr AddrOfPinnedObject()
        {
            return handle.AddrOfPinnedObject();
        }

        protected virtual void Dispose(bool disposing)
        {
            handle.Free();
        }

        public static implicit operator GCHandle(SmartGCHandle other)
        {
            return other.handle;
        }
    }
}