using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] GameObject hitGroundEffect;
	[SerializeField] GameObject hitDmgEffect;

	[SerializeField] float destroyAfterTime = 5f;

	private void Start()
	{
		StartCoroutine(DestroyBulletAfterTime());
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
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

	public IEnumerator DestroyBulletAfterTime()
	{
		yield return new WaitForSeconds(destroyAfterTime);
		Destroy(gameObject);
	}
}

