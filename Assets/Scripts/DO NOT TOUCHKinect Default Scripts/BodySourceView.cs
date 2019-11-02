using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour
{
    private readonly Dictionary<ulong, GameObject> _Bodies = new Dictionary<ulong, GameObject>();
    private BodySourceManager _BodyManager;

    private readonly Dictionary<JointType, JointType> _BoneMap =
        new Dictionary<JointType, JointType>
        {
            {JointType.FootLeft, JointType.AnkleLeft},
            {JointType.AnkleLeft, JointType.KneeLeft},
            {JointType.KneeLeft, JointType.HipLeft},
            {JointType.HipLeft, JointType.SpineBase},

            {JointType.FootRight, JointType.AnkleRight},
            {JointType.AnkleRight, JointType.KneeRight},
            {JointType.KneeRight, JointType.HipRight},
            {JointType.HipRight, JointType.SpineBase},

            {JointType.HandTipLeft, JointType.HandLeft},
            {JointType.ThumbLeft, JointType.HandLeft},
            {JointType.HandLeft, JointType.WristLeft},
            {JointType.WristLeft, JointType.ElbowLeft},
            {JointType.ElbowLeft, JointType.ShoulderLeft},
            {JointType.ShoulderLeft, JointType.SpineShoulder},

            {JointType.HandTipRight, JointType.HandRight},
            {JointType.ThumbRight, JointType.HandRight},
            {JointType.HandRight, JointType.WristRight},
            {JointType.WristRight, JointType.ElbowRight},
            {JointType.ElbowRight, JointType.ShoulderRight},
            {JointType.ShoulderRight, JointType.SpineShoulder},

            {JointType.SpineBase, JointType.SpineMid},
            {JointType.SpineMid, JointType.SpineShoulder},
            {JointType.SpineShoulder, JointType.Neck},
            {JointType.Neck, JointType.Head}
        };

    public GameObject bodySourceManager;
    public Material boneMaterial;

    private void Update()
    {
        if (bodySourceManager == null) return;

        _BodyManager = bodySourceManager.GetComponent<BodySourceManager>();
        if (_BodyManager == null) return;

        var data = _BodyManager.GetData();
        if (data == null) return;

        var trackedIds = new List<ulong>();
        foreach (var body in data)
        {
            if (body == null) continue;

            if (body.IsTracked) trackedIds.Add(body.TrackingId);
        }

        var knownIds = new List<ulong>(_Bodies.Keys);

        // First delete untracked bodies
        foreach (var trackingId in knownIds)
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(_Bodies[trackingId]);
                _Bodies.Remove(trackingId);
            }

        foreach (var body in data)
        {
            if (body == null) continue;

            if (body.IsTracked)
            {
                if (!_Bodies.ContainsKey(body.TrackingId)) _Bodies[body.TrackingId] = CreateBodyObject(body.TrackingId);

                RefreshBodyObject(body, _Bodies[body.TrackingId]);
            }
        }
    }

    private GameObject CreateBodyObject(ulong id)
    {
        var body = new GameObject("Body:" + id);

        for (var jt = JointType.SpineBase; jt <= JointType.ThumbRight; jt++)
        {
            var jointObj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            var lr = jointObj.AddComponent<LineRenderer>();
            lr.SetVertexCount(2);
            lr.material = boneMaterial;
            lr.SetWidth(0.05f, 0.05f);

            jointObj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            jointObj.name = jt.ToString();
            jointObj.transform.parent = body.transform;
        }

        return body;
    }

    private void RefreshBodyObject(Body body, GameObject bodyObject)
    {
        for (var jt = JointType.SpineBase; jt <= JointType.ThumbRight; jt++)
        {
            var sourceJoint = body.Joints[jt];
            Joint? targetJoint = null;

            if (_BoneMap.ContainsKey(jt)) targetJoint = body.Joints[_BoneMap[jt]];

            var jointObj = bodyObject.transform.Find(jt.ToString());
            jointObj.localPosition = GetVector3FromJoint(sourceJoint);

            var lr = jointObj.GetComponent<LineRenderer>();
            if (targetJoint.HasValue)
            {
                lr.SetPosition(0, jointObj.localPosition);
                lr.SetPosition(1, GetVector3FromJoint(targetJoint.Value));
                lr.SetColors(GetColorForState(sourceJoint.TrackingState),
                    GetColorForState(targetJoint.Value.TrackingState));
            }
            else
            {
                lr.enabled = false;
            }
        }
    }

    private static Color GetColorForState(TrackingState state)
    {
        switch (state)
        {
            case TrackingState.Tracked:
                return Color.green;

            case TrackingState.Inferred:
                return Color.red;

            default:
                return Color.black;
        }
    }

    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}