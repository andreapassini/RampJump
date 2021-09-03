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
    public float attackRate = 2f;
    float nextAttackTime;

    private bool isShooting;

	private void Start()
	{
        isShooting = false;
	}

	// Update is called once per frame
	void Update()
    {
        if(Time.time >= nextAttackTime) {
            if (Input.GetButtonDown("Fire1") && !isShooting) {
                Shoot();
                nextAttackTime = Time.time + rechargeTime;
            }
        }

    }

    void Shoot()
	{
        GameObject bullet = Instantiate(bulletPrfab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        //Test attackRate /out Coroutine
        //isShooting = true;

        //StartCoroutine(Recharge());
	}


    //La funzione serve per inserire tempo di ricarica tra uno sparo ed il successivo
    public IEnumerator Recharge()
	{
        yield return new WaitForSeconds(rechargeTime);
        isShooting = false;
    }
}
