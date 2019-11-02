using System.Runtime.InteropServices;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.DepthSpacePoint
    //
    [StructLayout(LayoutKind.Sequential)]
    public struct DepthSpacePoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DepthSpacePoint)) return false;

            return Equals((DepthSpacePoint) obj);
        }

        public bool Equals(DepthSpacePoint obj)
        {
            return X.Equals(obj.X) && Y.Equals(obj.Y);
        }

        public static bool operator ==(DepthSpacePoint a, DepthSpacePoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(DepthSpacePoint a, DepthSpacePoint b)
        {
            return !a.Equals(b);
        }
    }
}