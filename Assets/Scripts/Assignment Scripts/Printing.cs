using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assignment_Scripts
{
    public class Printing
    {
        internal FileStream FileStreamField { get; set; }
        #region printing_Methods
        internal void PrintList(string line, string path, string nameOfFile)
        {
            Debug.Log("Printing:" + line);
            PrintListGeneric(line, path, nameOfFile);
        }

        // Generic Print method that takes in generic Datatype T and Prints it out 
        private void PrintListGeneric<T>(T line, string path, string nameOfFile)
        {
            //writes the data of the body positions as a plaintext document
            /*
             * REFERENCE LAYOUT OF JOINTS IN THE FILE
             * 
             */
            /*
             *  SpineBase (Root)
             *  SpineMid
             *  Neck
             *  Head
             *  ShoulderLeft
             *  ElbowLeft
             *  WristLeft
             *  HandLeft
             *  ShoulderRight
             *  ElbowRight
             *  WristRight
             *  HandRight
             *  HipLeft
             *  KneeLeft
             *  AnkleLeft
             *  FootLeft
             *  HipRight
             *  KneeRight
             *  AnkleRight
             *  FootRight
             *  SpineShoulder
             *  HandTipLeft
             *  ThumbLeft
             *  HandTipRight
             *  ThumbRight
             */
            var filePath = path + nameOfFile;
            var lineStr = line.ToString();
            lineStr = lineStr.Replace("(", "");
            lineStr = lineStr.Replace(")", "");
            FileStreamField.Close();
            File.AppendAllText(filePath, lineStr + Environment.NewLine, Encoding.UTF8);
            FileStreamField.Close();
        }
        #endregion


        public static List<Vector3> LoadData(string filePath, string fileName)
        {
            var list = new List<Vector3>();
            
            // Reads through a file and converts the string to a list of string lines and then into a list of vector3 using LINQ expression
            
            try
            {
                var array = File.ReadAllLines(filePath + fileName);

                list.AddRange(array.Select(line => line.Split(','))
                    .Select(strings => new Vector3(
                        x: Convert.ToSingle(strings[0]), 
                        y: Convert.ToSingle(strings[1]),
                        z: Convert.ToSingle(strings[2])
                    )));
            }
            catch (IOException e)
            {
                Debug.LogError("File Doesn't Exist");
                Debug.LogError(e);
            }
            
            return list;

        }
    }
}