using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 83;
    public GameObject panel;
    public Text sure;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            sure.text = "Kalan Süre:" + timeRemaining.ToString();
        }

        else{
            
            panel.SetActive(true);
            Time.timeScale = 0;

        }
    }
}