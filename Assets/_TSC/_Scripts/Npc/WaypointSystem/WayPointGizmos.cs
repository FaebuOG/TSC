using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WayPointGizmos 
{
    private static readonly float width = 0.5f;
    private static readonly float halfWidth = width / 2;
    [DrawGizmo(GizmoType.NonSelected|GizmoType.Selected|GizmoType.Pickable,typeof(Waypoint))]
  public static void DrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType) 
    {
        DrawStartPoint(waypoint);
        DrawOrintation(waypoint);
    } 
    private static void DrawStartPoint(Waypoint waypoint) 
    {
        if (waypoint.previousWaypoint)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(waypoint.transform.position, halfWidth);
    }
    private static void DrawOrintation(Waypoint waypoint)
    {
    }
}
