using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningController : MonoBehaviour
{
    #region Variables

    public Transform[] spwanPoints;
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


	private void Start()
	{
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
	}

	//Player is alive?
	public object Spawner(object o)
	{
		return null;
	}

	// DT Conditions

	public object CheckDistance(object o)
	{
		if ((player.transform.position - transform.position).magnitude < 0) {
			return true;
		}
		return false;
	}

	public IEnumerator PatrolDT()
	{
		while (true) {
			dt.walk();
			yield return new WaitForSeconds(reactionTime);
		}
	}

	#endregion
}
