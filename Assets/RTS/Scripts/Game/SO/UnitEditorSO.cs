using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(UnitSO))]
public class UnitSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        UnitSO unitSO = (UnitSO)target;
        if (GUILayout.Button("��������� � JSON"))
        {
            string path = EditorUtility.SaveFilePanel(
                "��������� JSON",
                Application.dataPath,
                $"{unitSO.Name}_Data.json",
                "json");

            if (!string.IsNullOrEmpty(path))
            {
                unitSO.SaveToJson(path);
            }
        }
    }
}
