using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Path path;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int nextWaypointIndex = 1;
    [SerializeField] private float reachedWaypointClearance = 0.25f;

    private void Awake()
    {
        path = FindAnyObjectByType<Path>();
    }
    void Start()
    {
        transform.position = path.waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, path.waypoints[nextWaypointIndex].position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, path.waypoints[nextWaypointIndex].position) <= reachedWaypointClearance) 
        { 
            nextWaypointIndex = nextWaypointIndex + 1;
        }

        if (nextWaypointIndex >= path.waypoints.Length) 
        {
            nextWaypointIndex = 0;
        }

    }
}
