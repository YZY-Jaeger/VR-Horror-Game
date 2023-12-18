using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField] private Waypoint waypoints;

    [SerializeField] public FieldOfView FOV;

    [Range(0f, 5f)]
    [SerializeField] private float moveSpeed = 3f;

    [Range(0f,10f)]
    [SerializeField] private float rotateSpeed = 4f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Transform currentWaypoint;

    private Quaternion rotationGoal;

    private Vector3 directionToWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.getNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.getNextWaypoint(currentWaypoint);
        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (FOV.canSeePlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, FOV.target.position, (moveSpeed / 4) * Time.deltaTime);
            RotateTowardsWaypoint();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.getNextWaypoint(currentWaypoint);
            }
            RotateTowardsWaypoint();
        }
    }

    private void RotateTowardsWaypoint()
    {
        if (FOV.canSeePlayer)
        {
            directionToWaypoint = (FOV.target.position - transform.position).normalized;
            rotationGoal = Quaternion.LookRotation(directionToWaypoint);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
        }
        else
        {
            directionToWaypoint = (currentWaypoint.position - transform.position).normalized;
            rotationGoal = Quaternion.LookRotation(directionToWaypoint);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, rotateSpeed * Time.deltaTime);
        }
    }
}
