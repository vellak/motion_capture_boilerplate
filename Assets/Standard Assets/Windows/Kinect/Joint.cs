using System.Runtime.InteropServices;
using RootSystem = System;

namespace Windows.Kinect
{
    //
    // Windows.Kinect.Joint
    //
    [StructLayout(LayoutKind.Sequential)]
    public struct Joint
    {
        public JointType JointType { get; set; }
        public CameraSpacePoint Position { get; set; }
        public TrackingState TrackingState { get; set; }

        public override int GetHashCode()
        {
            return JointType.GetHashCode() ^ Position.GetHashCode() ^ TrackingState.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Joint)) return false;

            return Equals((Joint) obj);
        }

        public bool Equals(Joint obj)
        {
            return JointType.Equals(obj.JointType) && Position.Equals(obj.Position) &&
                   TrackingState.Equals(obj.TrackingState);
        }

        public static bool operator ==(Joint a, Joint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Joint a, Joint b)
        {
            return !a.Equals(b);
        }
    }
}