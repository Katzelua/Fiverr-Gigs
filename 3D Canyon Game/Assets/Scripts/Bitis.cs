using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    

public class Bitis : MonoBehaviour
{

    public GameObject panel;
    
    public void LoadScene()
      { 
          SceneManager.LoadScene("Oyun");
       }

    void OnTriggerEnter(Collider col){
        if(col.tag == "car"){
        panel.SetActive(true);
        Time.timeScale = 0;
        }
    }
}
