using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFreezeRotation : MonoBehaviour
{
    public GameObject bot;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (bot.transform.position.x, bot.transform.position.y + 2, bot.transform.position.z + 4);
    }
}
