using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    #region Variables

    public int selectedWeapon = 0;
    

    #endregion

    #region Unity Methods

    void Start()
    {
        SelctedWeapon();
    }

    void Update()
    {
        int previusSelectedWeapon = selectedWeapon;

        /*
        if(Input.GetAxis("Mouse SCrollWheel") > 0f) {
            //Mi assicuro che se giro ancora la rotellina torni alla prima
            if(selectedWeapon >= transform.childCount - 1) 
                selectedWeapon = 0;
			else
                selectedWeapon++;
		}
        if (Input.GetAxis("Mouse SCrollWheel") < 0f) {
            //Mi assicuro che se giro ancora la rotellina torni alla prima
            if (selectedWeapon <= 0 ) 
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }
       
        */

        int i = 0;

        foreach(Transform weapon in transform) {
			if (Input.GetKeyDown(i.ToString())){
                selectedWeapon = i;
			}
		}

        if (previusSelectedWeapon != selectedWeapon) {
            SelctedWeapon();
        }
    }

    void SelctedWeapon()
	{
        int i = 0;
        foreach(Transform weapon in transform) {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
		}
	}

    #endregion
}
