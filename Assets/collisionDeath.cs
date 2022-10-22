using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "bot") {
            Destroy(col.gameObject.transform.parent.gameObject);
        }
    }
}
