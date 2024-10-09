using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int bulletsAmount;
    [SerializeField] float bulletForce = 50f;
    [SerializeField] float delay = 1f;

    private float time = 0f;
    private bool isReloaded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isReloaded)
        {
            Reload();
        }
    }

    public void Shoot()
    {
        if (bulletsAmount > 0)
        {
            if (isReloaded)
            {
                CreateBullet();
                isReloaded = false;
            }
        }
        else
        {
            Debug.Log("No bullets!");
        }
    }

    private void CreateBullet()
    {
        bulletsAmount--;
        GameObject bullet = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        Vector3 localForward = transform.TransformDirection(Vector3.forward);
        bullet.GetComponent<Rigidbody>().AddForce(localForward * bulletForce, ForceMode.Impulse);
    }

    private void Reload()
    {
        if (time <= 0f)
        {
            isReloaded = true;
            time = delay;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
