using UnityEditor;
using UnityEngine;

namespace Assignment_Scripts.Editor
{
    [CustomEditor(typeof(CompareBodyPositions))]
    public class CompareUiEditor : UnityEditor.Editor
    {
        public Data.Characters member;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var manager = (CompareBodyPositions) target;
            // Creates a button to generate the files instead of a key press

            if (manager.systemChoice.Equals(Data.SystemToUse.System2))
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Band Member:");
                member = (Data.Characters) EditorGUILayout.EnumPopup("", member);
                manager.member = member;
                EditorGUILayout.LabelField("Match Tolerance:");
                manager.MatchTolerance = EditorGUILayout.DoubleField(manager.MatchTolerance);
            }


            else if (manager.systemChoice.Equals(Data.SystemToUse.System3))
            {
                EditorGUILayout.Separator();
                EditorGUILayout.LabelField("Band Member:");
                member = (Data.Characters) EditorGUILayout.EnumPopup("", member);
                manager.member = member;
                EditorGUILayout.LabelField("Distance Tolerance:");
                manager.DirCompareTolerance = EditorGUILayout.DoubleField(manager.DirCompareTolerance);
            }
            if (GUILayout.Button("Compare Body"))
            {
                if (EditorApplication.isPlaying)
                    manager.RunSystem();
                else
                    Debug.Log("Can't run unless in Play Mode");
            }
        }
    }
}