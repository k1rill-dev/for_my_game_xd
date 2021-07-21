using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor.Callbacks;

public class Shotgun : MonoBehaviour
{
	public Transform firePoint;
	public GameObject shotgunBullet;
	public int currentAmmo = 8;
	public int allAmmo = 0;
	public int fullAmmo = 24;
	public bool isReloading = false;

	//Weapon w = new Weapon();

	[SerializeField]
	private Text ammoCount;

	
	void Update()
	{
		ammoCount.text = currentAmmo + " / " + allAmmo;
		//w.ammoCount.text = w.currentAmmo + " / " + w.allAmmo;
		if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
		{
			Shoot();
			currentAmmo -= 1;
		}
		if (Input.GetKeyDown(KeyCode.R) && allAmmo > 0)
		{
			StartCoroutine(Reload());
			isReloading = true;
		}
	}
	void Shoot()
	{
		Instantiate(shotgunBullet, firePoint.position, firePoint.rotation);
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
	//	if (collision.GetComponent<PistolClip>())
	//	{
	//		w.allAmmo += 15;
	//		Destroy(collision.gameObject);
	//	}
		//else
		if (collision.gameObject.tag == "ShotgunClip")
		{
			allAmmo += 8;
			Destroy(collision.gameObject);
		}

	}
	IEnumerator Reload()
	{
		int reason = 8 - currentAmmo;

		if (allAmmo >= reason)
		{
			for (int i = 0; i < reason; i++)
			{
				yield return new WaitForSeconds(1);
				currentAmmo += 1;
				allAmmo -= 1;
			}
		}
		else 
		{
			for (int i = 0; i < allAmmo; i++)
			{
				yield return new WaitForSeconds(1);
				currentAmmo += 1;
				allAmmo -= 1;
			}
		}
	
	}
}
