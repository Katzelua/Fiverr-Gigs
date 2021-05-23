using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float moveSpeed;
	public GameObject camera;
	public GameObject totaledtank;
	public Transform target;
	public int health = 100;
	public GameObject deathEffect;
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float aimSpeed = 5f;
	public float fireRate = 1F;
    private float nextFire = 0.0F;
	public GameObject namlu;
	public Transform Allychecker;
	

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	void Update()
    {
		

        if(Vector2.Distance(transform.position, target.position) > 10)
			transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
		else
			transform.position = Vector2.MoveTowards(transform.position, target.position, -moveSpeed * Time.deltaTime);
	
		
		Vector2 direction = target.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		namlu.transform.rotation = Quaternion.Slerp(namlu.transform.rotation, rotation, aimSpeed* Time.deltaTime);
		
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Shoot();
		}
		
    }
	
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Shoot ()
	{		
		RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.TransformDirection(Vector2.right),10f);
		if(hit.collider.name == "Player"){
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);	
		FindObjectOfType<AudioManager>().Play("atis");	
		}		
	}
	
	void Die ()
	{
		Instantiate(totaledtank, transform.position, transform.rotation);
		CameraShake cam = camera.GetComponent<CameraShake>();
		cam.ShakeIt();
		FindObjectOfType<AudioManager>().Play("explosion");
		Destroy(gameObject);
		
	}

}