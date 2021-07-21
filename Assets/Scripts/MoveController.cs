using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	public PlayerController controller;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public int damage = 30;
	public Enemy en;
	
	void Update ()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
		//if (Input.GetButtonDown("Crouch"))
		//{
		//	crouch = true;
		//} else if (Input.GetButtonUp("Crouch")) 
		//{
		//	crouch = false;
		//}
	}
	void FixedUpdate() 
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy") 
		{
			en.TakeDamage(damage);
		}
		
	}

}
