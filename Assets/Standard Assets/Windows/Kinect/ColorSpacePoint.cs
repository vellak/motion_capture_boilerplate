using System.Runtime.InteropServices;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorSpacePoint
    //
    [StructLayout(LayoutKind.Sequential)]
    public struct ColorSpacePoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ColorSpacePoint)) return false;

            return Equals((ColorSpacePoint) obj);
        }

        public bool Equals(ColorSpacePoint obj)
        {
            return X.Equals(obj.X) && Y.Equals(obj.Y);
        }

        public static bool operator ==(ColorSpacePoint a, ColorSpacePoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ColorSpacePoint a, ColorSpacePoint b)
        {
            return !a.Equals(b);
        }
    }
}