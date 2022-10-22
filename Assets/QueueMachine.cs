using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class QueueMachine : MonoBehaviour
{
    public Queue<GameObject> MachineQueue = new Queue<GameObject>();
    public List<GameObject> machines;
    public GameObject[] publicQueue;

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (GameObject bot in MachineQueue) {
            bot.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("machineQ"+i.ToString()).transform.position);
	        i++;
        }
        publicQueue = MachineQueue.ToArray();
    }

    public void LoadBotMachine(GameObject botArrivedMachine) {
        foreach (GameObject machine in machines)
        {
            if(machine.GetComponent<colliderListener>().isColliding == false) {
                MachineQueue.Enqueue(botArrivedMachine);
                // Debug.Log("we let you in");
                return;
            } else {
                botArrivedMachine.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("done").transform.position);
                // Debug.Log("wont let you in");
            }
        }
    }
}