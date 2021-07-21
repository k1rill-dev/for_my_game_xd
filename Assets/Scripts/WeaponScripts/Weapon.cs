using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Callbacks;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject pistolBullet;
	public int currentAmmo = 15;
	public int allAmmo = 0;
	public int fullAmmo = 45;
	private Shotgun sh;
	
	[SerializeField]
	public Text ammoCount;

	void Update() 
	{
		if (Input.GetButtonDown("Fire1") && currentAmmo > 0) 
		{
			Shoot();
			currentAmmo -= 1;
		}
		ammoCount.text = currentAmmo + " / " + allAmmo;
		if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0) 
		{
			Reload();
		}
		if (currentAmmo == 0) 
		{
			Reload();
		}
	
	}
	void Shoot() 
	{
		Instantiate(pistolBullet, firePoint.position, firePoint.rotation);
	}
	void OnTriggerEnter2D(Collider2D collision) 
	{
		if (collision.gameObject.tag == "PistolClip")
		{
			allAmmo += 15;
			Destroy(collision.gameObject);
		}
		else if (collision.gameObject.tag == "ShotgunClip") 
		{
			sh.allAmmo += 8;
			Destroy(collision.gameObject);
		}
		
	}
	void Reload() 
	{
		int reason = 15 - currentAmmo;
		if (allAmmo >= reason)
		{
			allAmmo = allAmmo - reason;
			currentAmmo = 15;
		}
		else 
		{
			currentAmmo = currentAmmo + allAmmo;
			allAmmo = 0;
		}
	}
}
	
