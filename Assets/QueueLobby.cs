using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class QueueLobby : MonoBehaviour
{
    public Queue<GameObject> lobbyQueue = new Queue<GameObject>();
    public GameObject[] lobbyPositions;
    public GameObject[] publicQueue;

    // Update is called once per frame
    void Update()
    {
        int e = 0;
        foreach (GameObject bot in lobbyQueue) {
            bot.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("lobbyQ"+e.ToString()).transform.position);
	        e++;
        }

        publicQueue = lobbyQueue.ToArray();
    }

    public void LoadBotLobby(GameObject botArrivedLobby) {
        foreach (GameObject lobby in lobbyPositions)
        {
            if(lobby.GetComponent<colliderListener>().isColliding == false) {
                lobbyQueue.Enqueue(botArrivedLobby);
                // Debug.Log("we let you in");
                return;
            } else {
                botArrivedLobby.GetComponent<BotScript>().agent.SetDestination(GameObject.Find("done").transform.position);
                // Debug.Log("won't let in");
            }
        }
    
    }
}
