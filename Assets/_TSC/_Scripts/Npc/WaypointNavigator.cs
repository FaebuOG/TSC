using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    //made with Boundfox Studios Tutorial
    private class Predictedmovement 
    {
        public Vector3 position;
        public Quaternion LookRotation;
    }
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private Rigidbody rigidbody;

    private Waypoint waypoint;
    private bool shouldNavigate;
    private float Threshold => Time.fixedDeltaTime * speed;

    public void StartAt(Waypoint startWaypoint)
    {
        waypoint = startWaypoint;

        rigidbody.position = startWaypoint.transform.position;
        shouldNavigate = true;
    }
    private void FixedUpdate()
    {
        if (!shouldNavigate ||HasReachedEnd())
        {
            shouldNavigate = false;
            return;
        }
        var predictedMovement = PredictMove(waypoint.nextWaypoint, Time.deltaTime);
        rigidbody.MovePosition(predictedMovement.position);
        rigidbody.MoveRotation(predictedMovement.LookRotation);

        if (HasReachedWaypoint(waypoint.nextWaypoint, rigidbody.position))
        {
            waypoint = waypoint.nextWaypoint;

        }
    }
    private Predictedmovement PredictMove(Waypoint waypointPos, float time) 
    {
        var finalPosition = rigidbody.position;
        for (float step = 0f; step < time; step+= Time.fixedDeltaTime)
        {
            var position = finalPosition;
            var direction = position - waypointPosition(waypointPos);
            var normalizedDirection = direction.normalized;

            finalPosition = position - normalizedDirection * speed * Time.fixedDeltaTime;

            if (HasReachedWaypoint(waypointPos,finalPosition ))
            {
                waypointPos = waypointPos.nextWaypoint;

            }
        }
        var movementDirection = finalPosition - rigidbody.position;
        var lookRotation = Quaternion.FromToRotation(Vector3.forward, movementDirection);

        return new Predictedmovement()
        {
            position = finalPosition,
            LookRotation = lookRotation
        };
    }
    private bool HasReachedWaypoint(Waypoint waypoint, Vector3 position) 
    {
        return Vector3.Distance(position, waypoint.transform.position) < Threshold;
    }
    private bool HasReachedEnd() 
    {
        return !waypoint.nextWaypoint && HasReachedWaypoint(waypoint, rigidbody.position);
    }
    private Vector3 waypointPosition(Waypoint waypoint) 
    {
        var position = waypoint.transform.position;
        return new Vector3(position.x, position.y, position.z);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
