using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    // ABSTRACTION
    [SerializeField] private List<Transform> waypoints;

    private int currentWaypointNum = 0;

    public Transform GetCurrentWaypoint()
    {
        return waypoints[currentWaypointNum];
    }

    public void WaypointReached()
    {
        currentWaypointNum++;

        if (currentWaypointNum == waypoints.Count)
        {
            currentWaypointNum = 0;
        }
    }
}
