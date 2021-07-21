using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

	public int weaponSwitch = 0;
	bool akPickUp = false;
	bool shotgunPickUp = false;

	void Start () 
	{
		SelectWeapon();
	}
	
	void Update ()
	{
		int currentWeapon = weaponSwitch;
		if (Input.GetKeyDown(KeyCode.Alpha1)) 
		{
			weaponSwitch = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) && shotgunPickUp == true)
		{
			weaponSwitch = 1;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) && akPickUp == true)
		{
			weaponSwitch = 2;
		}
		if (currentWeapon != weaponSwitch) 
		{
			SelectWeapon();
		}
	}

	void SelectWeapon()
	{
		int i = 0;
		foreach (Transform weapon in transform)
		{
			if (i == weaponSwitch)
				weapon.gameObject.SetActive(true);
			else
				weapon.gameObject.SetActive(false);
			i++;
		}
	}
	void OnTriggerEnter2D(Collider2D collision) 
	{
		if (collision.gameObject.tag == "AK")
		{
			akPickUp = true;
			Destroy(collision.gameObject);
		}
		else if (collision.gameObject.tag == "Shotgun") 
		{
			shotgunPickUp = true;
			Destroy(collision.gameObject);
		}
	}
}
