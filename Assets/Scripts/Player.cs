using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] float mouseSensitivity = 100.0f; // Sensitivity of the mouse input
    [SerializeField] Transform cam;

    protected override void Look()
    {
        // Получение ввода от пользователя
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
    }

    protected override void Shoot()
    {
        if (Input.GetMouseButton(0) && gun)
        {
            gun.Shoot();
        }
    }

    protected override void Move()
    {
        // Получение ввода от пользователя
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(direction * speed);
    }

    protected override void Death()
    {
        bool isPlayerWin = false;
        gameController.GameOver(isPlayerWin);
    }
}
