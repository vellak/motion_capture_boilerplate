using System.Runtime.InteropServices;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.JointOrientation
    //
    [StructLayout(LayoutKind.Sequential)]
    public struct JointOrientation
    {
        public JointType JointType { get; set; }
        public Vector4 Orientation { get; set; }

        public override int GetHashCode()
        {
            return JointType.GetHashCode() ^ Orientation.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is JointOrientation)) return false;

            return Equals((JointOrientation) obj);
        }

        public bool Equals(JointOrientation obj)
        {
            return JointType.Equals(obj.JointType) && Orientation.Equals(obj.Orientation);
        }

        public static bool operator ==(JointOrientation a, JointOrientation b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(JointOrientation a, JointOrientation b)
        {
            return !a.Equals(b);
        }
    }
}