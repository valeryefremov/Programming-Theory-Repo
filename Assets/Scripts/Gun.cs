using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    // ABSTRACTION
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int bulletsAmount;
    [SerializeField] private float bulletForce = 50f;
    [SerializeField] private float delay = 1f;
    [SerializeField] private Text bulletsAmountText;

    private float time = 0f;
    private bool isReloaded = false;

    // Start is called before the first frame update
    private void Start()
    {
        ShowBulletsText();
    }

    // Update is called once per frame
    private void Update()
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
        ShowBulletsText();
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

    private void ShowBulletsText()
    {
        if (bulletsAmountText)
        {
            bulletsAmountText.text = "Bullets: " + bulletsAmount;
        }
    }
}
