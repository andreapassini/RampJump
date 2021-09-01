using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrfab;

    public float bulletForce = 20f;

    [SerializeField] float rechargeTime = 0.5f;
    private bool isShooting;

	private void Start()
	{
        isShooting = false;
	}

	// Update is called once per frame
	void Update()
    {
		if (Input.GetButtonDown("Fire1") && !isShooting) {

            Shoot();
		}
    }

    void Shoot()
	{
        GameObject bullet = Instantiate(bulletPrfab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        isShooting = true;

        StartCoroutine(Recharge());
	}


    //La funzione serve per inserire tempo di ricarica tra uno sparo ed il successivo
    public IEnumerator Recharge()
	{
        yield return new WaitForSeconds(rechargeTime);
        isShooting = false;
    }
}
