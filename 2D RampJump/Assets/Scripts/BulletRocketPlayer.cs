using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRocketPlayer : Bullet
{
	#region Variables

	public string target = "Enemy";
	public int damage = 10;

	#endregion

	#region Unity Methods

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == target) {
			collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
	}

	#endregion
}
