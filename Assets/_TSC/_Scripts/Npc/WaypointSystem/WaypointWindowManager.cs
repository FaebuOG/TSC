using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointWindowManager : EditorWindow
{
    //made with Boundfox Studios Tutorial
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
        if (GUILayout.Button("Rename all Waypoints"))
        {
            RenameAllWaypoints();

        }
        if (GUILayout.Button("Create Waypoint"))
        {
            CreateWayPoint();
        }
        var selectedWaypoint = GetSelectedWaypoint();
        GUI.enabled = selectedWaypoint;

        var waypointName = selectedWaypoint ? $"{selectedWaypoint.name}" : string.Empty;

        if (GUILayout.Button($"Create waypoint before{waypointName}"))
        {
            CreateWaypointBefore(selectedWaypoint);

        }
        if (GUILayout.Button($"Create waypoint after{waypointName}"))
        {
            CreateWaypointAfter(selectedWaypoint);

        }
        if (GUILayout.Button($"Delete{selectedWaypoint}"))
        {
            DeleteWaypoint(selectedWaypoint);

        }
    }
    private void CreateWaypointBefore(Waypoint selectedWaypoint) 
    {
        var beforeWaypoint = CreateNewWaypoint();
        beforeWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex());

        beforeWaypoint.PreviousWaypoint = selectedWaypoint.PreviousWaypoint;

        if (beforeWaypoint.PreviousWaypoint)
        {
            beforeWaypoint.PreviousWaypoint.NextWaypoint = beforeWaypoint;

        }
        beforeWaypoint.NextWaypoint = selectedWaypoint;
        beforeWaypoint.NextWaypoint.PreviousWaypoint = beforeWaypoint;

        OrientWaypoint(beforeWaypoint, selectedWaypoint);
        Selection.activeGameObject = beforeWaypoint.gameObject;

        RenameAllWaypoints();
    }
    private void CreateWaypointAfter(Waypoint selectedWaypoint)
    {
        var afterWaypoint = CreateNewWaypoint();
        afterWaypoint.transform.SetSiblingIndex(selectedWaypoint.transform.GetSiblingIndex() + 1);

        afterWaypoint.NextWaypoint = selectedWaypoint.NextWaypoint;

        if (afterWaypoint.NextWaypoint)
        {
            afterWaypoint.NextWaypoint.PreviousWaypoint = afterWaypoint;

        }
        afterWaypoint.PreviousWaypoint = selectedWaypoint;
        afterWaypoint.PreviousWaypoint.NextWaypoint = afterWaypoint;

        OrientWaypoint(afterWaypoint, selectedWaypoint);
        Selection.activeGameObject = afterWaypoint.gameObject;

        RenameAllWaypoints();
    }
    private void DeleteWaypoint(Waypoint selectedWaypoint)
    {
        if (selectedWaypoint.PreviousWaypoint)
        {
            selectedWaypoint.PreviousWaypoint.NextWaypoint = selectedWaypoint.NextWaypoint;

        }
        if (selectedWaypoint.NextWaypoint)
        {
            selectedWaypoint.NextWaypoint.PreviousWaypoint = selectedWaypoint.PreviousWaypoint;
        }
        DestroyImmediate(selectedWaypoint.gameObject);
        RenameAllWaypoints();
    }
    private Waypoint GetSelectedWaypoint() 
    {
        return Selection.activeGameObject ? Selection.activeGameObject.GetComponent<Waypoint>() : null;
    }
    private void RenameAllWaypoints() 
    {
        for (int i = 0; i < WayPointsRoot.childCount; i++)
        {
            WayPointsRoot.GetChild(i).name = $"Waypoint{i + 1}";

        }
    }
    private void CreateWayPoint() 
    {
        var waypoint = CreateNewWaypoint();

        if (WayPointsRoot.childCount > 1)
        {
            waypoint.PreviousWaypoint = WayPointsRoot.GetChild(waypoint.transform.GetSiblingIndex() - 1).GetComponent<Waypoint>();
            waypoint.PreviousWaypoint.NextWaypoint = waypoint;

            OrientWaypoint(waypoint,waypoint.PreviousWaypoint);
        }

        Selection.activeGameObject = waypoint.gameObject;

    }
    private void OrientWaypoint(Waypoint waypoint, Waypoint reference) 
    {
        if (!reference)
        {
            return;
        }

        var waypointTransform = waypoint.transform;
        var referenceTransform = reference.transform;

        waypointTransform.SetPositionAndRotation(referenceTransform.position, referenceTransform.rotation);
    }
    private Waypoint CreateNewWaypoint()
    {
        var waypointGameObject = new GameObject($"Waypoint{WayPointsRoot.childCount+1}", typeof(Waypoint));
        waypointGameObject.transform.SetParent(WayPointsRoot.transform, false);

        return waypointGameObject.GetComponent<Waypoint>();
    }
}
