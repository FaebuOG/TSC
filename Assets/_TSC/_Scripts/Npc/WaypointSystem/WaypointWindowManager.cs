using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointWindowManager : EditorWindow
{
    [MenuItem("Tools/Waypoint Manager")]
   private static void ShowWindow() 
    {
        var window = GetWindow<WaypointWindowManager>();
        window.titleContent = new GUIContent("Waypoint Manager");
        window.Show();
    }
    public Transform WayPointsRoot;
    private void OnGUI()
    {
        var serielizedEditorWindow = new SerializedObject(this);

        EditorGUILayout.PropertyField(serielizedEditorWindow.FindProperty(nameof(WayPointsRoot)));

        if (!WayPointsRoot)
        {
            EditorGUILayout.HelpBox("Bitte zuerst Waypoints Root eingeben",MessageType.Info);

        }
        else
        {
            DrawButtons();
        }
        serielizedEditorWindow.ApplyModifiedProperties();
    }

    private void DrawButtons() 
    {
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWayPoint();
        }
    }
    private void CreateWayPoint() 
    {
        var waypoint = CreateNewWaypoint();

        Selection.activeGameObject = waypoint.gameObject;

    }
    private Waypoint CreateNewWaypoint()
    {
        var waypointGameObject = new GameObject($"Waypoint{WayPointsRoot.childCount+1}", typeof(Waypoint));
        waypointGameObject.transform.SetParent(WayPointsRoot.transform, false);

        return waypointGameObject.GetComponent<Waypoint>();
    }
}
