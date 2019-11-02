using System;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Assignment_Scripts
{
    public class MoveLineVectors : MonoBehaviour
    {
        private Vector3 _previousPosition;

        private readonly List<Vector3Tuple> _originalPositions = new List<Vector3Tuple>();

        // Start is called before the first frame update
        private void Start()
        {
            var list = transform.GetComponentsInChildren<LineRenderer>();
            foreach (var rend in list)
            {
                _originalPositions.Add(
                    new Vector3Tuple(
                        rend.GetPosition(0),
                        rend.GetPosition(1)
                ));
            }
        }

        private void LateUpdate()
        {
            if (gameObject.transform.hasChanged)
            {
                var children = transform.GetComponentsInChildren<LineRenderer>();
                for (var index = 0; index < children.Length; index++)
                {
                    var lineRenderer = children[index];
                    // shifts the position of the lines 
                    var position = transform.position;
                    lineRenderer.SetPosition(0, _originalPositions[index].GetValues()[0] + position);
                    lineRenderer.SetPosition(1, _originalPositions[index].GetValues()[1] + position);
                }
            } 
        }

        [Serializable]
        private struct Vector3Tuple
        {
            private readonly Vector3 _a;
            private readonly Vector3 _b;
            public Vector3Tuple(Vector3 a,Vector3 b)
            {
                _a = a;
                _b = b;
            }

            public List<Vector3> GetValues()
            {
                var list = new List<Vector3> {_a, _b};
                return list;
            }

            public Vector3 GetDirectionVector3(VectorDirection direction)
            {
                switch (direction)
                {
                    // Gets the direction of the two vector points
                    
                    case VectorDirection.AToB:
                    {
                        var dx = _a.x - _b.x;
                        var dy = _a.y - _b.y;
                        var dz = _a.z - _b.z;
                        return  new Vector3(dx,dy,dz);
                    }
                    case VectorDirection.BToA:
                    {
                        var dx = _b.x - _a.x;
                        var dy = _b.y - _a.y;
                        var dz = _b.z - _a.z;
                        return  new Vector3(dx,dy,dz);
                    }
                    default:
                        throw new Exception();
                }
            }
            public enum VectorDirection
            {
                AToB,
                BToA
            }
            
        }
        /*
         * ANIMATION STUFF
         * each key frame will be have a linear interpolation between them
         *
         * Saving of the Lists<vector3>
         *     method(Object obj, float interval,int iterations)
         *     {
         *         get all joints in obj
         *         and save positions
         *         repeat at interval for amount of iterations.
         *     }
         *
         *
         * PART 1
         *
         * this animates the body over multiple keyframes over time.
         * 
         * Method that takes in 2 parameters
         * method(List<vector3> body, List<List<Vector3>> keyframes)
         * {
         * loop through every list in the keyframes list
         * define the current list as b
         * 
         *    foreach : vector in list a
         *             move vector to corresponding vector in list b over time
         *
         *    
         * }
         *TODO this
         * 
         *
         *PART 2
         *
         * implement Part 1 but with a trigger, and the trigger only gets triggered when
         * a system 2 returns a true
         * 
         * when its triggered the keyframe will change and the bodies will interpolate
         * 
         */
        
    }
}
