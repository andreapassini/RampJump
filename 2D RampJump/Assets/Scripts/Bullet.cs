using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] GameObject hitGroundEffect;
	[SerializeField] GameObject hitDmgEffect;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Rigidbody2D _rigidbody2D;

		_rigidbody2D = collision.rigidbody;

		//Effetto diverso a seconda di cosa si colpisce
		/*
		
		if (_rigidbody2D.tag == "Ground") {
			GameObject effect = Instantiate(hitGroundEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
		}

		if (_rigidbody2D.tag == "Damage") {
			GameObject effect = Instantiate(hitDmgEffect, transform.position, Quaternion.identity);
			Destroy(effect, 5f);
		}

		*/
		
		GameObject effect = Instantiate(hitGroundEffect, transform.position, Quaternion.identity);
		Destroy(effect, 2f);
		Destroy(gameObject);
	}
}
