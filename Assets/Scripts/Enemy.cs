using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private Waypoint Waypoint;
    private Transform Target;
    private int WaypointIndex;

    private float Speed = 1.5f;

    [Inject]
    public void Construct(Waypoint waypoint)
    {
        Waypoint = waypoint;
    }

    private void Start()
    {
        WaypointIndex = 0;
        Target = Waypoint.Waypoints.ElementAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(Target.position, transform.position) < 0.2f)
        {
            MoveToNextWaypoint();
        }
    }

    private void MoveToNextWaypoint()
    {
        WaypointIndex++;
        Target = Waypoint.Waypoints.ElementAt(WaypointIndex);
    }
}
