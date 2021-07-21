using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Grenade : MonoBehaviour {

	public float delay = 3f;
	float countdown;
	bool isExploided = false;
	public Text granadeCounter;
	public int maxGrenades = 3;
	int radius;

	void Start () 
	{
		countdown = delay;
	}
	
	
	void Update () 
	{
		countdown -= Time.deltaTime;
		if (countdown <= 0f && !isExploided) 
		{
			Explode();
			isExploided = true;
		}

	}
	void Explode()
	{
		   Physics2D.OverlapBoxAll(transform.position, transform.position ,radius);
		
		Destroy(gameObject);
	}

}
