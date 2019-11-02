using System.Collections.Generic;
using UnityEngine;

namespace Assignment_Scripts
{
    public static class NormaliseBodyCoords
    {

        public static List<Vector3> Normalise(List<Vector3> jointList)
        {
            var normalisedList = new List<Vector3> {new Vector3()};
            var rootPos = jointList[0];
            foreach (var joint in jointList)
            {
                // translates the position of each joint by that which the root is offset by
                //and add the new vector to the list after getting normalised;
                // the root will automatically be set to 0,0,0
                var vector = (joint - rootPos).normalized;
                normalisedList.Add(vector); 
            }
            return normalisedList;
        }
 /*
  * while seeming to be inefficient in the code, where looking up the normalised value of one point requires calculating all the points in the list
  * this is a required step in the process as any point requires the root value set at 0,0,0 and 
  */
        public static Vector3 Normalise(List<Vector3> jointList, int positionInList)
        {
            return  Normalise(jointList)[positionInList];        
        }
    }
}
