using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col){
        if(col.tag == "ai")
        col.gameObject.SetActive(false);
    }
}
