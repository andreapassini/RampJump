using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	#region Variables

	public GameObject hitGroundEffect;
	public GameObject hitDmgEffect;

	[SerializeField] float destroyAfterTime = 5f;

	public string target = "Enemy";
	public int damage = 10;

	#endregion

	#region Unity Methods

	private void Start()
	{
		StartCoroutine(DestroyBulletAfterTime());
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject effect;

		//Effetto diverso a seconda di cosa si colpisce
		if (collision.gameObject.tag == target) {
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
			effect = Instantiate(hitDmgEffect, transform.position, Quaternion.identity);
		} else {
			effect = Instantiate(hitGroundEffect, transform.position, Quaternion.identity);
		}

		Destroy(effect, 2f);
		Destroy(gameObject);
	}

	public IEnumerator DestroyBulletAfterTime()
	{
		yield return new WaitForSeconds(destroyAfterTime);
		Destroy(gameObject);
	}

	#endregion

}

