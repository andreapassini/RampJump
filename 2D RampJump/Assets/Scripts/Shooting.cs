using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrfab;

    public float bulletForce = 20f;

    public Text ammoDisplay;
    public int ammo = 10;
    
    [SerializeField] float rechargeTime = 0.5f;
    float nextAttackTime;

    private bool isShooting;

	private void Start()
	{
        isShooting = false;
        ammoDisplay.text = this.ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime && this.ammo>0) {
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

        useAmmo(1);

        //Test attackRate /out Coroutine
        //isShooting = true;

        //StartCoroutine(Recharge());
	}


    //Funzione di gestione delle munizioni
    public void useAmmo(int nAmmo)
	{
        this.ammo -= nAmmo;
        ammoDisplay.text = this.ammo.ToString();
    }

    public void rechargeAmmo(int nAmmo)
	{
        this.ammo += nAmmo;
        ammoDisplay.text = this.ammo.ToString();
    }

}
