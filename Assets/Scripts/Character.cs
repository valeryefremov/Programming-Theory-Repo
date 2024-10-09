using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] protected float speed = 1.0f; // Скорость перемещения
    [SerializeField] protected Gun gun;

    private float health;

    protected Rigidbody rb;
    protected GameController gameController;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        health = maxHealth;
    }

    protected virtual void Update()
    {
        if (!gameController.IsGameOver)
        {
            Look();
            Shoot();
            ShowHealth();
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!gameController.IsGameOver)
        {
            Move();
        }
    }

    public void Damage(float damageAmount)
    {
        damageAmount = Mathf.Abs(damageAmount);
        AddHealth(-damageAmount);
    }

    public void Heal(float healAmount)
    {
        healAmount = Mathf.Abs(healAmount);
        AddHealth(healAmount);
    }

    private void AddHealth(float amount)
    {
        if (!gameController.IsGameOver)
        {
            health += amount;
            health = Mathf.Clamp(health, 0f, 100f);

            if (health == 0f)
            {
                Death();
                ShowHealth(0);
            }  
        }
    }

    protected virtual void Death()
    {
       
    }

    protected virtual void Move()
    {

    }

    protected virtual void Look()
    {

    }

    protected virtual void Shoot()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Damage(5f);
        }
    }

    void ShowHealth()
    {
        Vector3 tmp = healthBar.rectTransform.localScale;
        tmp.x = health / maxHealth;
        healthBar.rectTransform.localScale = tmp;
    }

    void ShowHealth(float amount)
    {
        Vector3 tmp = healthBar.rectTransform.localScale;
        tmp.x = amount;
        healthBar.rectTransform.localScale = tmp;
    }
}
