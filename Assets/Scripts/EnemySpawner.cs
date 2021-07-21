using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject[] enemies;
	public GameObject[] bosses;
	
	public int timeForSpawn = 3;
	public int timeForBossSpawn = 10;
	private int randSpawn;
	Vector2 whereToSpawn;
	float randX;
	int randBossSpawn;



	void Update ()
	{
		if (!IsInvoking("Spawn"))
		{
			Invoke("Spawn", timeForSpawn);
		}
		if (!IsInvoking("SpawnBoss")) 
		{
			Invoke("SpawnBoss", timeForBossSpawn);
		}
		randSpawn = Random.Range(0, enemies.Length);
		randBossSpawn = Random.Range(0, bosses.Length);
		randX = Random.Range(-19.53f, 19.53f);
		whereToSpawn = new Vector2(randX, transform.position.y);
	}
	void Spawn()
	{
		Instantiate(enemies[randSpawn], whereToSpawn, spawnPoint.rotation);
	}
	void SpawnBoss()
	{
		Instantiate(bosses[randBossSpawn], whereToSpawn, spawnPoint.rotation);
	}

}
