using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] EnemyWaypoints enemyWaypoints;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    Damage(5f);
        //}
    }

    void FixedUpdate()
    {
        Move();
    }

    protected override void Death()
    {
        Debug.Log("Enemy Died");
        Destroy(gameObject);
    }

    protected override void Move()
    {
        Vector3 direction = Vector3.zero;

        if (enemyWaypoints)
        {
            direction = (enemyWaypoints.GetCurrentWaypoint().position - transform.position).normalized;
        }

        rb.AddForce(direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            enemyWaypoints.WaypointReached();
        }
    }
}
