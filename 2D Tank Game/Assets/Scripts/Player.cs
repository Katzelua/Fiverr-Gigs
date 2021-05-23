using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	public float turnspeed = 10.0f; // nişan alma hızı
	public float health = 100;
	public Image healthBar;
	public Image manaBar;
	public float lerpSpeed;
	public GameObject deathEffect;
	public GameObject namlu;
	public float speed = 1.0f;
	public Transform firePoint;
	public GameObject bulletPrefab;
    public float fireRate = 1F;
    public float nextFire = 0.0F;
	public AudioSource ausrc;
	public GameObject totaledtank;
	public GameObject Losepanel;
	
	public void Start(){
		lerpSpeed = 3f * Time.deltaTime;
	}
	public void Update(){
		
		BarFill();
		ColorChanger();
		namlu.transform.Rotate(Vector3.forward * turnspeed * Input.GetAxis("Vertical") * Time.deltaTime); // nişan alma
		
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			manaBar.fillAmount = 0;
			FindObjectOfType<AudioManager>().Play("atis");
			

		}
		
		var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
         transform.position += move * speed * Time.deltaTime;
		
		if (Input.GetAxis("Horizontal") != 0)
        {
            
			ausrc.pitch = Mathf.Lerp(ausrc.pitch, 1.50f, 0.1f);	
			ausrc.volume = Mathf.Lerp(ausrc.volume, 0.1f, 0.1f);
        }
		
		else{
			ausrc.pitch = Mathf.Lerp(ausrc.pitch, 1f, 0.1f);
			ausrc.volume = Mathf.Lerp(ausrc.volume, 0.05f, 0.1f);
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
	
	void BarFill(){
		
		healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health/100 ), lerpSpeed);
		manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, 1f, lerpSpeed);		
	}
	
	void ColorChanger()
	{
		Color healthColor = Color.Lerp(Color.red, Color.green, (health/100));
		healthBar.color = healthColor;
	}
	void Die ()
	{
		Instantiate(totaledtank, transform.position, transform.rotation);
		Losepanel.SetActive(true);
		Destroy(gameObject);
	}

}