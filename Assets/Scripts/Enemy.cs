using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Enemy : Character
{
    // ABSTRACTION
    [SerializeField] private EnemyWaypoints enemyWaypoints;

    private Transform player;
    private float timeToShoot;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // POLYMORPHISM
    protected override void Look()
    {
        transform.LookAt(player);
    }

    // POLYMORPHISM
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

    // POLYMORPHISM
    protected override void Move()
    {
        Vector3 direction = Vector3.zero;

        if (enemyWaypoints)
        {
            direction = (enemyWaypoints.GetCurrentWaypoint().position - transform.position).normalized;
        }

        rb.AddForce(direction * speed);
    }

    // POLYMORPHISM
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
