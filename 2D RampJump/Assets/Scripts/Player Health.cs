using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    #region Variables
    public GameObject losePanel;

    public Text healthDisplay;
    public int health;
    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        //Add sound to demage taken
    
        //source.Play();
        this.health -= damageAmount;
        healthDisplay.text = health.ToString();
            
        //Se la vita è <0, allora elimina player
        if (this.health <= 0) {
            healthDisplay.text = "0";
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    #endregion
}
