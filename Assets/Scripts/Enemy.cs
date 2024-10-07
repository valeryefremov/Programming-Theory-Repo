using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    Damage(5f);
        //}
    }

    protected override void Death()
    {
        Debug.Log("Enemy Died");
    }
}
