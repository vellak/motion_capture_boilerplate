using System.Runtime.InteropServices;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.CameraSpacePoint
    //
    [StructLayout(LayoutKind.Sequential)]
    public struct CameraSpacePoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CameraSpacePoint)) return false;

            return Equals((CameraSpacePoint) obj);
        }

        public bool Equals(CameraSpacePoint obj)
        {
            return X.Equals(obj.X) && Y.Equals(obj.Y) && Z.Equals(obj.Z);
        }

        public static bool operator ==(CameraSpacePoint a, CameraSpacePoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CameraSpacePoint a, CameraSpacePoint b)
        {
            return !a.Equals(b);
        }
    }
}