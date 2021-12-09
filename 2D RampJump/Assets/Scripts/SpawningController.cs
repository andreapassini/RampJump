using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
	#region Variables

	[Space]
	public GameObject[] areas;
	public float[] radiusValues;

	[Space]
	public GameObject[] enemies;

	public GameObject root;

    //Per gestire l'errore di quando il Player è morto
    public GameObject player;

	//DT
	public float reactionTime = 3f;
	private DecisionTree dt;


	#endregion

	#region Unity Methods

	// First approach:
	//	Pre-calculate distances from root to every spawning points
	//		(5 distance calculation)
	//	DO just player-root distance check

	//Second approach: (THIS)
	//	Tree
	//	Root and Nodes
	//	2 player-root distance checks

	//Range of each areas
	private void OnDrawGizmos()
	{
		int i;

		for (i = 0; i < areas.Length; i++) {
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(areas[i].transform.position, radiusValues[i]); 
		}
	}
	


	private void Start()
	{

		/*
		//Create DT

		//DT

		// Define actions
		DTAction a1 = new DTAction(Spawner);
		DTAction a2 = new DTAction(TurnOn);

		// Define decisions
		DTDecision d1 = new DTDecision(EnemiesAround);
		DTDecision d2 = new DTDecision(AlliesAround);

		// Link action with decisions
		d1.AddLink(true, a1);
		d1.AddLink(false, a2);

		// Setup my DecisionTree at the root node
		dt = new DecisionTree(d1);

		// Start monitoring
		StartCoroutine(PatrolDT());


		// start coroutine patrol
		*/

		//Gizmos.DrawSphere()

		//CircleCollider2D[] areas = gameObject.GetComponentsInChildren<CircleCollider2D>();

		StartCoroutine(PatrolSpawner());
	}

	public void SpawningPoint()
	{
		for(int i=0; i<areas.Length; i++) {
			if(PlayerInRange(areas[i], radiusValues[i])) {
				Spawner(areas[i]);
			}
		}
	}	

	
	public void Spawner(GameObject area)
	{
		Debug.Log("Spawner of: " + area);
		Instantiate(enemies[0], player.transform.position, player.transform.rotation);

		Transform[] spawningPoints = new Transform[area.transform.childCount];

		for (int i =0; i < area.transform.childCount; i++) {
			spawningPoints[i] = area.transform.GetChild(i);
		}
		
		foreach (Transform p in spawningPoints) {
			Instantiate(enemies[0], p.position, p.rotation);
		}
	}

	// DT Conditions

	public bool PlayerInRange(GameObject area, float range)
	{
		//float distance = (player.transform.position - area.transform.position).magnitude;
		float distance = Vector2.Distance(player.transform.position, area.transform.position);
		if (distance <= range) {
			Debug.Log(area + " IN: " + range + " => " + distance);
			return true;
		}
		Debug.Log(area + " NOT in: " + range + " - " + distance);
		return false;
	}

	public IEnumerator PatrolSpawner()
	{
		while (true) {
			SpawningPoint();
			yield return new WaitForSeconds(reactionTime);
		}
	}

	#endregion
}
