using System.IO;
using UnityEngine;

namespace Assignment_Scripts
{
    public class Data : MonoBehaviour
    {
        public enum Characters
        {
            Freddie,
            Roger,
            Brian,
            John,
            //Fill and remove as needed
            // Important when editing Enum that you also modify the switch conditions in the <CompareBodyPositions.cs> & <Data.cs> Files,
            // and add Internal string Files into the <Data.cs> file. 
            
        }

        // System Stuff
        public enum SystemToUse
        {
            System2,
            System3,
            System4
        }

        // file paths to the Band Members
        [SerializeField] internal string bandFilePath;

        [SerializeField] internal string brianFile = "Brian.txt";
        [SerializeField] internal string debugFileName = "Debug.txt";
        [SerializeField] internal string freddieFile = "Freddie.txt";
        [SerializeField] internal string johnFile = "John.txt";
        [SerializeField] internal string normVecFileName = "Normalised.txt";

        [Space]
        // Debugging Files
        [SerializeField] internal string debugPath;
        [SerializeField] internal string rogerFile = "Roger.txt";
        [SerializeField] internal string vectorFileName = "positions.txt";

        [Space]
        // Target Files
        [SerializeField]
        public string targetPath = @"Assets/prefab/Targets";

        public string GetCharacterFile(Characters character)
        {
            switch (character)
            {
                case Characters.Brian:
                    return brianFile;
                case Characters.Roger:
                    return rogerFile;
                case Characters.Freddie:
                    return freddieFile;
                case Characters.John:
                    return johnFile;
                default:
                    throw new IOException();
            }
        }
    }
}