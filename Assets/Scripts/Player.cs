using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Player : Character
{
    // ABSTRACTION
    [SerializeField] private float mouseSensitivity = 100.0f; // Sensitivity of the mouse input
    [SerializeField] private Transform cam;

    // POLYMORPHISM
    protected override void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }

    // POLYMORPHISM
    protected override void Shoot()
    {
        if (Input.GetMouseButton(0) && gun)
        {
            gun.Shoot();
        }
    }

    // POLYMORPHISM
    protected override void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(direction * speed);
    }

    // POLYMORPHISM
    protected override void Death()
    {
        bool isPlayerWin = false;
        gameController.GameOver(isPlayerWin);
    }
}
