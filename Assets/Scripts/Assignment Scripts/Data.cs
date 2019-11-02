using System.IO;
using Assignment_Scripts.enums;
using UnityEngine;



namespace Assignment_Scripts
{
    public class Data : MonoBehaviour
    {
        // System Stuff
      

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