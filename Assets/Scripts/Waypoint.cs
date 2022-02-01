using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Transform> Waypoints;

    private void Awake()
    {
        Waypoints = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Waypoints.Add(transform.GetChild(i));
        }
    }
}
