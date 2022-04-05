using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    
    public Waypoint startWaypoint;

    [SerializeField]
    private WaypointNavigator waypointNavigator;

    private void Awake()
    {
        if (startWaypoint)
        {
            waypointNavigator.StartAt(startWaypoint);

        }
    }

}
