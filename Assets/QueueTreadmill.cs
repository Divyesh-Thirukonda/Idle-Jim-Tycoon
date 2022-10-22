using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class QueueTreadmill : MonoBehaviour
{
    public Queue<GameObject> TreadmillQueue = new Queue<GameObject>();
    public List<GameObject> treads;
    public GameObject[] publicQueue;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject bot in TreadmillQueue) {
            bot.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("treadmillQ"+i.ToString()).transform.position);
	        i++;
        }

        publicQueue = TreadmillQueue.ToArray();
    }

    public void LoadBotTreadmill(GameObject botArrivedTreadmill) {
        foreach (GameObject tread in treads)
        {
            if(tread.GetComponent<colliderListener>().isColliding == false) {
                TreadmillQueue.Enqueue(botArrivedTreadmill);
                // Debug.Log("we let you in");
                return;
            } else {
                botArrivedTreadmill.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("done").transform.position);
                // Debug.Log("won't let in");
            }
        }
    }
}

