#pragma warning disable 618
using UnityEditor;
using UnityEngine;
using static UnityEditor.ReplacePrefabOptions;

namespace Assignment_Scripts.Editor
{
    [CustomEditor(typeof(LogicManager))]
    public class AssignmentLogicEditor : UnityEditor.Editor
    {
        public Data.Characters member;


        private LogicManager _Manager;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _Manager = (LogicManager) target;
            if (_Manager.typeToPrint == LogicManager.TypeToPrint.NewBandMember)
            {
                member = (Data.Characters) EditorGUILayout.EnumPopup("Choose Band Member", member);
                _Manager.characterToSerialize = member;
                
                
            }

            
            
            if (_Manager.typeToPrint.Equals(LogicManager.TypeToPrint.FullDebug) || _Manager.typeToPrint.Equals(LogicManager.TypeToPrint.All))
            {
                _Manager.normDebug = EditorGUILayout.Toggle("Normalised Inputs? : " , _Manager.normDebug);
            }
            
            
            
            // Creates a button to generate the files instead of a key press
            if (GUILayout.Button("Generate Files"))
            {
                if (EditorApplication.isPlaying)
                {
                    _Manager.GetAndSaveValues();
                    if (_Manager.typeToPrint == LogicManager.TypeToPrint.NewBandMember)
                    {
                        loadBody(_Manager.characterToSerialize);
                    }
                }
                else
                    Debug.Log("Can't Run unless in Play Mode");
            }
        }
        
        private void loadBody(Data.Characters character)
        {
            if (!(FindObjectsOfType(typeof(GameObject)) is GameObject[] gameObjects)) return;
            foreach (var Object in gameObjects)
            {
                if (Object.name.Contains("Body"))
                {
                    Debug.Log("Body Found" + Object);
                    var newObj = Object;
                    newObj.AddComponent<MoveLineVectors>();
                    CreateNewPrefab(Object, _Manager.dataFile.targetPath, character.ToString());
                }
            }
        }

        private static void CreateNewPrefab(GameObject obj, string path, string name)
        {
            PrefabUtility.SaveAsPrefabAsset(obj, path + name + ".prefab");
        }
    }

    
}