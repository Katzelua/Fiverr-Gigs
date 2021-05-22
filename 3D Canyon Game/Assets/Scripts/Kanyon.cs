using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    

public class Kanyon : MonoBehaviour
{

    public GameObject panel;
    
    // Start is called before the first frame update
    public void LoadScene()
      { 
          Time.timeScale = 1;
          SceneManager.LoadScene("Oyun");
       }

    void OnTriggerEnter(Collider col){
        if(col.tag == "car"){
        panel.SetActive(true);
        Time.timeScale = 0;
        }
    }
}
