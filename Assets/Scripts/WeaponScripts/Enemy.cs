using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 100;

	//public GameObject deathEffect;
	//скрипт создан скорее для отслеживания попаданий и здорвья ЛЮБОГО перса в игре
	public void TakeDamage(int damage) 
	{
		health -= damage;
		if (health <= 0) 
		{
			Die();
		}
	}
	void Die() 
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
