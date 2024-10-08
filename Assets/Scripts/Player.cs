using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    Damage(5f);
        //}
    }

    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    protected override void Death()
    {
        Debug.Log("Player Died");
    }

    protected override void Move()
    {
        // Получение ввода от пользователя
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(direction * speed);
    }

    protected override void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && gun)
        {
            gun.Shoot();
        }
    }
}
