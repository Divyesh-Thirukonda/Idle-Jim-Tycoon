using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderListener : MonoBehaviour
{
    public bool isColliding;
    
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "bot") {
            isColliding = true;
        }
    }
    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "bot") {
            isColliding = false;
        }
    }
}
