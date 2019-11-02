using System.Collections.Generic;
using Windows.Kinect;
using JetBrains.Annotations;
using UnityEngine;
using Joint = Windows.Kinect.Joint;

namespace Assignment_Scripts
{
    public partial class BodyWrapper
    {
        public BodyWrapper(byte index, [NotNull] Body bodyClass)
        {
            Index = index;
            BodyClass = bodyClass;
        }

        private byte Index { get; }
        public Body BodyClass { get; set; }

        private  CameraSpacePoint GetCameraSpacePoint(JointType index)
        {
            return BodyClass.Joints[index].Position;
        }

        private Vector3 ConvertJointPositionToVector(JointType i )
        {
            CameraSpacePoint position = GetCameraSpacePoint(i);
            return new Vector3(position.X * 10, position.Y * 10, position.Z * 10);
        }
        
        
        //Returns a Vector3 value of the requested 
        public Vector3 GetJointPosition(JointType index)
        {
            return ConvertJointPositionToVector(index);
        }

        public List<Vector3> GetAllJointPositions()
        {
            var listOfPositions = new List<Vector3>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var i = 0; i < BodyClass.Joints.Count; i++)
                listOfPositions.Add(
                    ConvertJointPositionToVector(BodyClass.Joints[(JointType) i].JointType));

            return listOfPositions;
        }

        public override string ToString()
        {
            return $"{nameof(Index)}: {Index}, {nameof(BodyClass)}: {BodyClass}";
        }

        public string JointValueDebug(bool isNormalised, Joint joint)
        {
            if (isNormalised)
            {
                return "BODY:: " +
                       Index +
                       "  |  TRACKING ID:: " +
                       BodyClass.TrackingId +
                       "  |  JOINT TYPE:: " +
                       joint.JointType +
                       "  |  JOINT POSITION:: " +
                       NormaliseBodyCoords.Normalise(GetAllJointPositions(), (int) joint.JointType);
            }
            else
            {
                return "BODY:: " +
                       Index +
                       "  |  TRACKING ID:: " +
                       BodyClass.TrackingId +
                       "  |  JOINT TYPE:: " +
                       joint.JointType +
                       "  |  JOINT POSITION:: " +
                       GetJointPosition(joint.JointType);
            }
        }
    }
}