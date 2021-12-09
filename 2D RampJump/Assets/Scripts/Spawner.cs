using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables

    public GameObject enemyPrefab1;
    private bool spawned;

    public string playerTag;

    public Transform[] spwanPoints;

    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == playerTag) {
            Spawn();
        }
            
    }

	public void Spawn()
	{
		if (!spawned) {
            Transform randomSpwanPoints = spwanPoints[Random.Range(0, spwanPoints.Length)];

            GameObject enemy = Instantiate(enemyPrefab1, randomSpwanPoints.position, transform.rotation);
            Rigidbody2D enemy_rb = enemy.GetComponent<Rigidbody2D>();

            

            spawned = true;       
        }
    }

	#endregion
}
