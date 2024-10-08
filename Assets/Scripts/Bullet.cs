using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}