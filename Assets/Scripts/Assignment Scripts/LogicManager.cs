using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Kinect;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assignment_Scripts
{
    public class LogicManager : MonoBehaviour
    {
        public enum TypeToPrint
        {
            FullDebug,
            Vectors,
            VectorsNormalised,
            NewBandMember,
            All
        }

        internal List<BodyWrapper> BodyWrappers;
        private List<Body> _bodyDataFromManager = new List<Body>();

        private Printing _printer;
        [HideInInspector] public bool normDebug;

       [HideInInspector] [Space] public Data.Characters characterToSerialize;

        public BodySourceManager bodyManager;

        [SerializeField] public Data dataFile;

        [SerializeField] public TypeToPrint typeToPrint;
        
        private void Start()
        {
            _printer = new Printing();
            BodyWrappers = new List<BodyWrapper>();
        }

        private void Update()
        {
            // Loads active bodies from the Body Manager
            /*
             * adds them to a list of BodyWrappers
             *
             * 
             */
            _bodyDataFromManager = new List<Body>(bodyManager.GetData());
            
            ExtractTrackableBodies();
            if (BodyWrappers == null) return;

            if (BodyWrappers.Count > 0)
            {
                if (Input.GetKeyDown(KeyCode.A)) GetAndSaveValues();
            }
            else
            {
                Debug.LogWarning("NO BODY FOUND : Most Likely no one is in the arena");
            }
        }
        #region printing
        public void GetAndSaveValues()
        {
            var normalizedPositions = new List<Vector3>();
            var positions = new List<string>();
            var debug = new List<string>();


            if (BodyWrappers == null) return;
            
            foreach (var body in BodyWrappers)
            {
                normalizedPositions.Clear();
                positions.Clear();
                debug.Clear();
                foreach (var joint in body.BodyClass.Joints)
                {
                    normalizedPositions = NormaliseBodyCoords.Normalise(body.GetAllJointPositions());
                        
                    positions.Add(body.GetJointPosition(joint.Key).ToString());
                    // checks between normalised values or normal values.
                    debug.Add(normDebug
                        ? body.JointValueDebug(true, joint.Value)
                        : body.JointValueDebug(false, joint.Value)
                        );
                }

                switch (typeToPrint)
                {
                    case TypeToPrint.FullDebug:
                    {
                        Print(TypeToPrint.FullDebug, debug);
                        //var readText = File.ReadAllText(dataFile.path + dataFile.debugFileName);
                        //Debug.Log(readText);
                        break;
                    }
                    case TypeToPrint.Vectors:
                    {
                        Print(TypeToPrint.Vectors, positions);
                        //var readText = File.ReadAllText(dataFile.path + dataFile.vectorFileName);
                        //Debug.Log(readText);
                        break;
                    }
                    case TypeToPrint.VectorsNormalised:
                    {
                        Print(TypeToPrint.VectorsNormalised, normalizedPositions);
                        //var readText = File.ReadAllText(dataFile.path + dataFile.normVecFileName);
                        //Debug.Log(readText);
                        break;
                    }
                    case TypeToPrint.All:
                    {
                        Print(TypeToPrint.VectorsNormalised, normalizedPositions);
                        Print(TypeToPrint.Vectors, positions);
                        Print(TypeToPrint.FullDebug, debug);
                        break;
                    }
                    case TypeToPrint.NewBandMember:


                        Print(TypeToPrint.NewBandMember, normalizedPositions);
                        break;
                    default:
                    {
                        Debug.LogError("NO PRINT TYPE SET");
                        break;
                    }
                }
            }
        }


        private void Print(TypeToPrint printType, IEnumerable<Vector3> list)
        {
            /*
             * Extension method for the print String to allow vectors to be passed
             */
            var strList = list.Select(joint => joint.ToString()).ToList();
            Print(printType,strList);
        }
        private void Print(TypeToPrint printType, List<string> list)
        {
            switch (printType)
            {
                case TypeToPrint.FullDebug:
                {
                    _printer.FileStreamField = File.Create(dataFile.debugPath + dataFile.debugFileName);
                    foreach (var line in list) _printer.PrintList(line, dataFile.debugPath, dataFile.debugFileName);

                    break;
                }
                case TypeToPrint.Vectors:
                {
                    _printer.FileStreamField = File.Create(dataFile.debugPath + dataFile.vectorFileName);
                    foreach (var line in list) _printer.PrintList(line, dataFile.debugPath, dataFile.vectorFileName);

                    break;
                }
                case TypeToPrint.VectorsNormalised:
                {
                    _printer.FileStreamField = File.Create(dataFile.debugPath + dataFile.normVecFileName);
                    foreach (var line in list) _printer.PrintList(line, dataFile.debugPath, dataFile.normVecFileName);

                    break;
                }
                case TypeToPrint.All:
                {
                    //HANDLED IN CALLING METHOD
                    break;
                }

                case TypeToPrint.NewBandMember:
                {
                    _printer.FileStreamField =
                        File.Create(dataFile.bandFilePath + dataFile.GetCharacterFile(characterToSerialize));
                    foreach (var line in list)
                        _printer.PrintList(line, dataFile.bandFilePath,
                            dataFile.GetCharacterFile(characterToSerialize));
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(list), list, null);
                }
            }
        }
        #endregion
        private void ExtractTrackableBodies()
        {
            
            if (_bodyDataFromManager == null) return;
            BodyWrappers.Clear();
            for (var positionIndex = 0; positionIndex < _bodyDataFromManager.Count; positionIndex++)
            {
                var body = _bodyDataFromManager[positionIndex];
                if (body?.IsTracked == true)
                    BodyWrappers.Add(new BodyWrapper((byte) positionIndex, body));
            }
        }
       
        //end of class
    }
}