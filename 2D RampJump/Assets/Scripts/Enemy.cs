using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;

	public GameObject deathEffect;

	private GameObject player;

	//2 DT
	public float reactionTime = 3f;

	//Behaviour
	//Emotion 
	[Range(0f, 20f)] public float range = 10f;
	[Range(0, 250)] public int emotionStartingValue = 100;
	[Range(0, 250)] private int emotionValue;

	public int highHealth;
	public int lowHealth;

	[SerializeField] private int emotionIncrease = 5;

	private DecisionTree dtEmo;
	private DecisionTree dt;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}

	private void Start()
	{
		player = GameObject.Find("Player");

		// DT

		// Define Actions
		// DTAction aT1 = new DTAction(ChasePlayer);
		// DTAction aT2 = new DTAction(RunAwayFromPlayer);
		// DTAction aT3 = new DTAction(Attack);
		// DTAction aT4 = new DTAction(Healing);

		// Define Decisions
		//DTDecision dT1 = new DTDecision(PlayerInRange);
		DTDecision dT2 = new DTDecision(AlliesAround);
		DTDecision dT3 = new DTDecision(PlayerInLineOfSight);
		//DTDecision dT4 = new DTDecision(IsHealing);

		// Link action with decisions


		//Emotion Tree
		emotionValue = emotionStartingValue;

		// Define actions
		DTAction a1 = new DTAction(IncreaseEmotionValue);
		DTAction a2 = new DTAction(DecreaseEmotionValue);
		DTAction a3 = new DTAction(IncreaseDoubleEmotionValue);
		DTAction a4 = new DTAction(DecreaseDoubleEmotionValue);

		// Define decisions
		DTDecision d1 = new DTDecision(AlliesAround);
		DTDecision d2 = new DTDecision(HighHealth);
		DTDecision d3 = new DTDecision(LowHealth);

		// Link action with decisions
		d1.AddLink(true, d2);
		d1.AddLink(false, d3);

		d2.AddLink(true, a3);
		d2.AddLink(false, a1);

		d3.AddLink(true, a4);
		d3.AddLink(true, a2);

		// Setup my DecisionTree at the root node
		dtEmo = new DecisionTree(d1);

		// Start patroling
		StartCoroutine(PatrolDt());
	}

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	public object IncreaseEmotionValue(object o)
	{
		emotionValue += emotionIncrease;
		return null;
	}

	public object IncreaseDoubleEmotionValue(object o)
	{
		emotionValue += (emotionIncrease * 2);
		return null;
	}

	public object DecreaseEmotionValue(object o)
	{
		emotionValue -= emotionIncrease;
		return null;
	}

	public object DecreaseDoubleEmotionValue(object o)
	{
		emotionValue -= (emotionIncrease * 2);
		return null;
	}

	// Check if there are enemies in range
	public object AlliesAround(object o)
	{
		foreach (GameObject go in GameObject.FindGameObjectsWithTag(transform.tag)) {
			if (Vector2.Distance(transform.position, go.transform.position) <= range) 
				return true;
		}
		return false;
	}

	public object HighHealth(object o)
	{
		if (health < highHealth)
			return true;
		return false;
	}

	public object LowHealth(object o)
	{
		if (health < lowHealth)
			return true;
		return false;
	}

	public object PlayerInLineOfSight(object o)
	{
		RaycastHit hit;
		Vector2 ray = player.transform.position - transform.position;

		if (Physics.Raycast(transform.position, ray, out hit)) {
			if (hit.transform == player.transform) {
				return true;
			}
		}

		return false;

	}

	public IEnumerator PatrolDt()
	{
		while (true) {
			dtEmo.walk();
			yield return new WaitForSeconds(reactionTime);
		}
	}
}
