using System;
using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine;
using Joint = Windows.Kinect.Joint;

namespace Assignment_Scripts
{
    public class CompareBodyPositions : MonoBehaviour
    {
        [NonSerialized] public double DirCompareTolerance = .2;
        public bool compareMultipleBodies = true;
        [SerializeField] private LogicManager manager;
        [NonSerialized] public double MatchTolerance = .2;
        public Data data;
        [HideInInspector] public Data.Characters member = Data.Characters.Freddie;
        [Header("COMPARE SETTINGS")] public Data.SystemToUse systemChoice;
        [SerializeField] private bool doDebug;

        public void RunSystem()
        {
            switch (systemChoice)
            {
                // takes in an enum of type System and runs teh appropriate method to each of the enum values
                case Data.SystemToUse.System2:
                {
                    System2(manager.BodyWrappers[0].GetAllJointPositions(), GetBody());
                    break;
                }
                case Data.SystemToUse.System3:
                {
                    System3(manager.BodyWrappers[0].GetAllJointPositions(), GetBody());
                    break;
                }
                case Data.SystemToUse.System4:
                {
                    if (compareMultipleBodies)
                    {
                        var value = System4(manager.BodyWrappers[0].GetAllJointPositions(), getBodyList());
                        if (value !=null)
                        {

                            Debug.Log(value);
                        }
                    }

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private bool System2(List<Vector3> liveInput, IEnumerable<Vector3> target)
        {
            var i = 0;
            liveInput = NormaliseBodyCoords.Normalise(liveInput);
            foreach (var joint in target)
            {
                

                // compare x
                // compare y

                // continues going through the list of bones till one is off
                //once it goes through the whole list then it its true
                // or else it returns false

                if (!CheckIfVectorIsApproxEqual(liveInput[i], joint))
                {
                    Debug.Log(false);
                    return false;
                }
                i++;
            }

            Debug.Log(true);
            return true;
        }

        private void System3(List<Vector3> liveInput, IEnumerable<Vector3> bodyTarget)
        {
            /*
             * Compares each joint within the live input to the corresponding joint within the target body 
             * and checks how far close the 2 directions are to each other
             */
            var i = 0;
            liveInput = NormaliseBodyCoords.Normalise(liveInput);
            foreach (var joint in bodyTarget)
            {
                var dirDif = CompareVectorDir(liveInput[i], joint);
                if ( dirDif < DirCompareTolerance)
                    Debug.Log(" joint " + (JointType)i +" is off by a direction product of: " + (DirCompareTolerance - dirDif));
                i++;
            }
        }

        private Data.Characters? System4(List<Vector3> liveInput, IList<List<Vector3>> targets)
        {
            /* take in an input of a list of Vector3 lists called A and a single vector3 list called B
             * compare each value in B to every value in each list of A 
             * by Using the System2 function to say whether the joints are close or not
             *
             * if it is a match return 
             */
            liveInput = NormaliseBodyCoords.Normalise(liveInput);
            foreach (var targetBody in targets)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                if (System2(targetBody, liveInput))
                {
                    return (Data.Characters) targets.IndexOf(targetBody);
                }
            }
            return null;
        }

        private static float CompareVectorDir(Vector3 a, Vector3 b)
        {
            // use this to compare how far away {Vector3 a} is from {Vector3 b}
            //returns a value between -1 and 1, 1 being the best.
            return Vector3.Dot(a, b);
        }

        private bool CheckIfVectorIsApproxEqual(Vector3 a, Vector3 b)
        {

            // Needs to adjust to make the SpineBase position be root.
            // checks all the coords of the two vectors {a} and {b} to see if the values are are close enough to each other, which is decided tru the {tolerance} value 
            if (doDebug)
            {
                Debug.Log(a.x + " " + b.x);
                Debug.Log(a.y + " " + b.y);
                Debug.Log("CALCULATING X : " + Mathf.Abs(a.x - b.x));
                Debug.Log("CALCULATING Y : " + Mathf.Abs(a.y - b.y));
            }
            return Mathf.Abs(a.x - b.x) <= MatchTolerance &&
                   Mathf.Abs(a.y - b.y) <= MatchTolerance;
        }

        private IEnumerable<Vector3> GetBody()
        {
            return member switch
            {
                Data.Characters.Freddie => Printing.LoadData(data.bandFilePath, data.freddieFile),
                Data.Characters.Roger => Printing.LoadData(data.bandFilePath, data.rogerFile),
                Data.Characters.Brian => Printing.LoadData(data.bandFilePath, data.brianFile),
                Data.Characters.John => Printing.LoadData(data.bandFilePath, data.johnFile),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private List<List<Vector3>> getBodyList()
        {
           // loads up the data
            var list = new List<List<Vector3>>
            {
                Printing.LoadData(data.bandFilePath, data.freddieFile),
                Printing.LoadData(data.bandFilePath, data.johnFile),
                Printing.LoadData(data.bandFilePath, data.brianFile),
                Printing.LoadData(data.bandFilePath, data.rogerFile)
            };
            return list;
        }

    }
}