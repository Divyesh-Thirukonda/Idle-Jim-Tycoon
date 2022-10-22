using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BotSpawner : MonoBehaviour
{
    public GameObject botToSpawn;
    public float rate;
    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 5;
        Instantiate(botToSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            Instantiate(botToSpawn, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
            spawnTimer = rate;
        }

        switch(DateTime.Now.DayOfWeek.ToString()) {
            case "Monday":
                rate = 17;
                break;
            case "Tuesday":
                rate = 15;
                break;
            case "Wednesday":
                rate = 10;
                break;
            case "Thursday":
                rate = 20;
                break;
            case "Friday":
                rate = 25;
                break;
            default:
                rate = 20;
                break;
        }
    }
}
