using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WayPointGizmos 
{
    //made with tutorial of Boundfox Studios
    private static readonly float width = 0.5f;
    private static readonly float halfWidth = width / 2;
    private static readonly float quarterWidth = width / 4;
    private static readonly float arrowHeadAngle = 20;
    private static readonly float arrowLength = 0.5f;

    [DrawGizmo(GizmoType.NonSelected|GizmoType.Selected|GizmoType.Pickable,typeof(Waypoint))]
  public static void DrawSceneGizmos(Waypoint waypoint, GizmoType gizmoType) 
    {
        DrawStartPoint(waypoint);
        DrawMidPoint(waypoint);
        DrawEndPoint(waypoint);

        DrawWalkLine(waypoint);

        DrawOrintation(waypoint);
    } 
    private static void DrawWalkLine(Waypoint waypoint) 
    {
        if (!waypoint.nextWaypoint)
        {
            return;
        }

        Gizmos.color = Color.white;
        var waypointPosition = waypoint.transform.position;
        var nextWaypointPosition = waypoint.nextWaypoint.transform.position;

        Gizmos.DrawLine(waypointPosition, nextWaypointPosition);
        var direction = (nextWaypointPosition - waypointPosition).normalized;
        if (direction == Vector3.zero) 
        {
            return;
        }

        var lookRotation = Quaternion.LookRotation(direction, Vector3.forward);
        var rightArrowHead = lookRotation * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * Vector3.forward;
        var leftArrowHead = lookRotation * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * Vector3.forward;

        Gizmos.DrawRay(nextWaypointPosition, rightArrowHead * arrowLength);
        Gizmos.DrawRay(nextWaypointPosition, leftArrowHead * arrowLength);
    }
    private static void DrawStartPoint(Waypoint waypoint) 
    {
        if (waypoint.previousWaypoint)
        {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(waypoint.transform.position, halfWidth);
    }
    private static void DrawEndPoint(Waypoint waypoint)
    {
        if (waypoint.nextWaypoint)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(waypoint.transform.position, halfWidth);
    }
    private static void DrawMidPoint(Waypoint waypoint)
    {
        if (!waypoint.nextWaypoint||!waypoint.previousWaypoint)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(waypoint.transform.position, quarterWidth);
    }
    private static void DrawOrintation(Waypoint waypoint)
    {
        Gizmos.color = Color.white;

        var transform = waypoint.transform;
        var offset = transform.forward  * halfWidth;
        var startPosition = transform.position;

        Gizmos.DrawLine(startPosition-offset,startPosition + offset);
    }
}
