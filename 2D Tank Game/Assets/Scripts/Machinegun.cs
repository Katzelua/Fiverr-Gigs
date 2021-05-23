using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour
{
    	public float fireRate = 1F;
    private float nextFire = 0.0F;
		public Transform firePoint;
	public GameObject bulletPrefab;
	public int health = 10;

    void Update()
    {
        if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Shoot();
		}
	}
		void Shoot ()
	{		
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);	
		FindObjectOfType<AudioManager>().Play("atismg");	
		}	
    
	
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}
}
