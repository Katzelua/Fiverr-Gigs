using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour {

	public float speed = 20f;
	public int damage = 25;
	public int damagePlayer = 25;
	public int damageboss = 10;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
		 StartCoroutine(SelfDestruct());
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		
		Player player = hitInfo.GetComponent<Player>();
		if (player != null)
		{
			player.TakeDamage(damagePlayer);
		}
		
		Spike spike = hitInfo.GetComponent<Spike>();
		if (spike != null)
		{
			spike.TakeDamage(damage);
		}
				
			Machinegun machinegun = hitInfo.GetComponent<Machinegun>();
		if (machinegun != null)
		{
			machinegun.TakeDamage(5);
		}
		
		Boss boss = hitInfo.GetComponent<Boss>();
		if (boss != null)
		{
			boss.TakeDamage(damageboss);
		}
		
		Med med = hitInfo.GetComponent<Med>();
		if (med != null)
		{
			med.TakeDamage(2);
		}
		

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
	
	IEnumerator SelfDestruct()
 {
     yield return new WaitForSeconds(1f);
     Destroy(gameObject);
 }
 

}