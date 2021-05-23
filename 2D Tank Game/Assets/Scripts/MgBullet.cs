using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgBullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
		 StartCoroutine(SelfDestruct());
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{

		
		Player player = hitInfo.GetComponent<Player>();
		if (player != null)
		{
			player.TakeDamage(1);
		}
		
	}
	
	IEnumerator SelfDestruct()
 {
     yield return new WaitForSeconds(0.5f);
     Destroy(gameObject);
 }
 

}