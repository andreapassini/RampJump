using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
	#region Variables
	public int health = 50;

	#endregion

	#region Unity Methods

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
			collision.GetComponent<PlayerHealth>().TakeHealth(health);
			Destroy(gameObject);
		}
	}

	#endregion
}
