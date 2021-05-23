using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Med : MonoBehaviour
{
    

public void TakeDamage (int damage)
	{
		
		if(damage > 1){
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health + 35;
			Destroy(gameObject);
		}
	}
}