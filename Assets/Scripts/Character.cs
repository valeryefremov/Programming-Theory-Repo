using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] protected float speed = 1.0f; // Скорость перемещения
    [SerializeField] protected Gun gun;

    private bool isDied;
    protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (!isDied)
        {
            health += amount;
            health = Mathf.Clamp(health, 0f, 100f);

            if (health == 0f)
            {
                isDied = true;
                Death();
            }
        }
        else
        {
            Debug.Log("Character Already Died!");
        }
    }

    protected virtual void Death()
    {
       
    }

    protected virtual void Move()
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
}
