using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float health;

    private bool isDied;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
