using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    #region Variables
    //public GameObject losePanel;

    public Text healthDisplay;
    public int health;

    [SerializeField] int startingHealth = 100;

    [SerializeField] float timeAfterHealth = 1f;
    float nextTimeHealth;

    #endregion

    #region Unity Methods

    void Start()
    {
        health = startingHealth;
        healthDisplay.text = health.ToString();
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        //Add sound DAMAGE
        //source.Play();

        this.health -= damageAmount;
        healthDisplay.text = health.ToString();
            
        //Se la vita è <0, allora elimina player
        if (this.health <= 0) {
            healthDisplay.text = "0";
            //losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void TakeHealth(int healthAmount)
	{
        //Add sound HEALTH
        //source.Play();

        if(Time.time >= nextTimeHealth) {
            nextTimeHealth = Time.time + timeAfterHealth;

            this.health += healthAmount;
            healthDisplay.text = health.ToString();
        }
    }

    #endregion
}
