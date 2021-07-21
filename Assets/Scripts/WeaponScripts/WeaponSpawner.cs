using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject[] weapons;
	public GameObject[] clips;
	public float timeToSpawnWeapons;
	public float timeToSpawnClips;
	int rand1;
	int rand2;
	float randX;
	Vector2 whereToSpawn;
	

	void Update ()
	{
		if (!IsInvoking("SpawnWeapon"))
		{
			Invoke("SpawnWeapon", timeToSpawnWeapons);
		}

		if (!IsInvoking("SpawnClips"))
		{
			Invoke("SpawnClips", timeToSpawnClips);
		}

		rand1 = Random.Range(0, weapons.Length);
		rand2 = Random.Range(0, clips.Length);
		randX = Random.Range(-13.23f, 13.23f);
		whereToSpawn = new Vector2(randX, transform.position.y);
	}
	void SpawnWeapon() 
	{
		Instantiate(weapons[rand1], whereToSpawn, spawnPoint.rotation);
	}
	void SpawnClips() 
	{
		Instantiate(clips[rand2], whereToSpawn, spawnPoint.rotation);
	}
}
