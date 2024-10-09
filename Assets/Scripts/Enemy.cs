using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] EnemyWaypoints enemyWaypoints;

    private Transform player;
    private float timeToShoot;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Look()
    {
        transform.LookAt(player);
    }

    protected override void Shoot()
    {
        if (timeToShoot <= 0f)
        {
            gun.Shoot();
            timeToShoot = Random.Range(0.2f, 5f);
        }
        else
        {
            timeToShoot -= Time.deltaTime;
        }
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

    protected override void Death()
    {
        bool isPlayerWin = true;
        gameController.GameOver(isPlayerWin);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Waypoint"))
        {
            enemyWaypoints.WaypointReached();
        }
    }
}
