using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class bullet : MonoBehaviour
{
	public float speed = 20f;
	public Rigidbody2D rb;
	public int damage = 20;
	//public GameObject impactEffect;
	

	void Start()
	{
		rb.velocity = transform.right * speed;
	}
	void OnTriggerEnter2D(Collider2D hitInfo) 
	{
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		//Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
