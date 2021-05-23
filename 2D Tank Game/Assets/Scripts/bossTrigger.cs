using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bosschech : MonoBehaviour
{
	public GameObject cam;
	public GameObject bosscam;	
	public GameObject boss;
	public Image imgLife1, imgLife2, imgLife3, imgLife4, imgLife5;
    void Start()
    {
        imgLife1.enabled = false;
        imgLife2.enabled = false;
        imgLife3.enabled = false;
		imgLife4.enabled = false;
        imgLife5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		
		Player player = hitInfo.GetComponent<Player>();
		if (player != null){
		boss.SetActive(true);
		bosscam.SetActive(true);
		cam.SetActive(false);
		imgLife1.enabled = true;
        imgLife2.enabled = true;
        imgLife3.enabled = true;
		imgLife4.enabled = true;
        imgLife5.enabled = true;
                

		}
	}
}
