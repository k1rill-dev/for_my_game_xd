using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AK : MonoBehaviour {
	public Transform firePoint;
	public GameObject akBullet;
	public int currentAmmo = 30;
	public int allAmmo = 0;
	public int fullAmmo = 90;

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
	}
	void Shoot()
	{
		Instantiate(akBullet, firePoint.position, firePoint.rotation);
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "AKClip")
		{
			allAmmo += 30;
			Destroy(collision.gameObject);
		}
	}
	void Reload()
	{
		int reason = 30 - currentAmmo;
		if (allAmmo >= reason)
		{
			allAmmo = allAmmo - reason;
			currentAmmo = 30;
		}
		else
		{
			currentAmmo = currentAmmo + allAmmo;
			allAmmo = 0;
		}
	}
}
