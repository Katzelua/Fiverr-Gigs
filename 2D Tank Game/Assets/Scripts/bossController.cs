using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	public float moveSpeed;
	public GameObject camera;
	public GameObject totaledtank;
	public Transform target;
	public float health = 100;
	public GameObject deathEffect;
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float aimSpeed = 5f;
	public float fireRate = 2F;
    private float nextFire = 0.0F;
	public GameObject namlu;
	public Image healthBar;
	public Image manaBar;
	public Image healthBarB;
	public Image manaBarB;
	public Image IMAGE;
	public float lerpSpeed;
	public GameObject Bossa;
	public GameObject Winpanel;

    void Start()
		{
		lerpSpeed = 3f * Time.deltaTime;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		}
	
	void Update()
    {
        ColorChanger();
		BarFill();
		
		if(Vector2.Distance(transform.position, target.position) > 20)
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
			manaBar.fillAmount = 0;
			Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			FindObjectOfType<AudioManager>().Play("bossatis");
			}

    }
	void ColorChanger()
	{
		Color healthColor = Color.Lerp(Color.red, Color.green, (health/100));
		healthBar.color = healthColor;
	}
	
	void BarFill(){
		
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health/100), lerpSpeed);
		manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, 1f, lerpSpeed);		
	}
	
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
		Instantiate(totaledtank, transform.position, transform.rotation);
		CameraShake cam = camera.GetComponent<CameraShake>();
		cam.ShakeIt();
		FindObjectOfType<AudioManager>().Play("explosion");
		Winpanel.SetActive(true);
		Destroy(Bossa);
		}
	}
}