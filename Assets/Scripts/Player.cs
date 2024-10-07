using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] float speed = 10.0f; // Скорость перемещения

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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

        // Создание вектора силы
        Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical) * 10f;

        // Применение силы к Rigidbody
        rb.AddForce(force);
    }
}
