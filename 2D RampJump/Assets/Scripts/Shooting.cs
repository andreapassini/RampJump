using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrfab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire1")) {

            Shoot();
		}
    }

    void Shoot()
	{
        GameObject bullet = Instantiate(bulletPrfab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}
}
