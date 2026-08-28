using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Trap))]
public class MyGameSettingsEditor : Editor {
    public override void OnInspectorGUI() {
        Trap settings = (Trap)target;

        settings.type = (Trap.TrapType)EditorGUILayout.EnumPopup("Trap Type", settings.type);
        EditorGUILayout.Space();

        switch (settings.type) {
            case Trap.TrapType.disappear:
                settings.delay = EditorGUILayout.FloatField("Delay", settings.delay);
                break;

            case Trap.TrapType.move:
                settings.moveTarget = EditorGUILayout.Vector2Field("Move Target", settings.moveTarget);
                settings.moveSpeed = EditorGUILayout.FloatField("Move Speed", settings.moveSpeed);
                break;

            case Trap.TrapType.rotate:
                settings.rotateAngle = EditorGUILayout.FloatField("Rotate Angle", settings.rotateAngle);
                settings.rotateSpeed = EditorGUILayout.FloatField("Rotate Speed", settings.rotateSpeed);
                break;
        }

        if (GUI.changed) {
            EditorUtility.SetDirty(settings);
        }
    }
}