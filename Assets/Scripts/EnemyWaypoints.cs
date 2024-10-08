using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaypoints : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    //public List<Transform> Waypoints { get { return waypoints; }}

    private int currentWaypointNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
