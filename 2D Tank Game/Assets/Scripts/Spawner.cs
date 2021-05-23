using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tank;
	public GameObject Spawnerr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		Player player = hitInfo.GetComponent<Player>();
		if (player != null)
		{
			Destroy(Spawnerr);
			Instantiate(Tank, transform.position, transform.rotation);

		}
		
		
	}
}
