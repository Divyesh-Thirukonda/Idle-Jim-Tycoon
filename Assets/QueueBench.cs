using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class QueueBench : MonoBehaviour
{
    public Queue<GameObject> BenchQueue = new Queue<GameObject>();
    public List<GameObject> benches;
    public GameObject[] publicQueue;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject bot in BenchQueue) {
            bot.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("benchQ"+i.ToString()).transform.position);
	        i++;
        }
        publicQueue = BenchQueue.ToArray();
    }

    public void LoadBotBench(GameObject botArrivedBench) {
        foreach (GameObject bench in benches)
        {
            if(bench.GetComponent<colliderListener>().isColliding == false) {
                BenchQueue.Enqueue(botArrivedBench);
                // Debug.Log("we let you in BIG");
                return;
            } else {
                botArrivedBench.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("done").transform.position);
                // Debug.Log("wont let you in BIG");
            }
        }
    }
}