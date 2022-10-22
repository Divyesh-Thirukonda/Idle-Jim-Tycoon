using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class BotScript : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject[] Locations;
    public TextMeshPro timerText;
    Dictionary<int, float> openWith;
    Dictionary<int, Queue<GameObject>> openWithAlso;

    public float timeVal = 0;
    public int i = 0;

    

    void Start()
    {
        openWith = new Dictionary<int, float>(){{1,GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYtime}, {2,GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLtime}, {3,GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHtime}, {4,GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINEtime}};
        
        Locations = new GameObject[] {GameObject.Find("lobby"), GameObject.Find("treadmillQ1"), GameObject.Find("benchQ1"), GameObject.Find("machineQ1"), GameObject.Find("done")};
        agent = GetComponent<NavMeshAgent>();

        GameObject.Find("lobby").GetComponent<QueueLobby>().LoadBotLobby(gameObject);
        // agent.SetDestination(Locations[0].transform.position);
        openWithAlso = new Dictionary<int, Queue<GameObject>>(){{1,GameObject.Find("lobby").GetComponent<QueueLobby>().lobbyQueue}, {2,GameObject.Find("treadmill").GetComponent<QueueTreadmill>().TreadmillQueue}, {3,GameObject.Find("bench").GetComponent<QueueBench>().BenchQueue}, {4,GameObject.Find("machine").GetComponent<QueueMachine>().MachineQueue}};
    }

    void Update()
    {
        if(open) {
            countCo();
        }
    }


    public bool open;
    void OnTriggerEnter (Collider collision) {
        if (collision.gameObject.name == "done") {
            Destroy(transform.parent.gameObject);
        }
    }
    void OnTriggerStay (Collider collision) {
        if (collision.gameObject.tag == "Stand") {
            timeVal += Time.deltaTime;
            InvokeRepeating("EE", .01f, 1f);
		    open = true;
        }
        if (collision.gameObject.tag == "bot") {
            agent.SetDestination(GameObject.Find("done").transform.position);
            openWithAlso[i].Dequeue();
            i=10;
        }
    }
    void OnTriggerExit (Collider collision) {
        if (collision.gameObject.tag == "Stand") {
            open = false;
        }
    }



    void countCo() {
        if(i == Locations.Length+2) {
            Destroy(gameObject);
        }

        if(timeVal > openWith[i]) {
            if (i == 1) {
                try {
                    GameObject.Find("treadmill").GetComponent<QueueTreadmill>().LoadBotTreadmill(gameObject);
                    GameObject.Find("lobby").GetComponent<QueueLobby>().lobbyQueue.Dequeue();
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYcashToAdd;
                    timeVal = 0;
                    timerText.text = "";
                    i = i + 1;
                } catch {
                    agent.SetDestination(GameObject.Find("done").transform.position);
                    GameObject.Find("lobby").GetComponent<QueueLobby>().lobbyQueue.Dequeue();
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYcashToAdd;
                    timeVal = 0;
                    timerText.text = "";
                }
            } else if (i == 2) {
                try {
                    GameObject.Find("bench").GetComponent<QueueBench>().LoadBotBench(gameObject);
                    GameObject.Find("treadmill").GetComponent<QueueTreadmill>().TreadmillQueue.Dequeue();
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().liquidCount += 10;
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLcashToAdd;
                    timeVal = 0;
                    timerText.text = "";
                    i = i + 1;
                } catch {
                    agent.SetDestination(GameObject.Find("done").transform.position);
                    GameObject.Find("treadmill").GetComponent<QueueTreadmill>().TreadmillQueue.Dequeue();
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().liquidCount += 10;
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLcashToAdd;
                    timeVal = 0;
                    timerText.text = "";
                }
            } else if (i == 3) {
                try {
                    GameObject.Find("machine").GetComponent<QueueMachine>().LoadBotMachine(gameObject);
                    GameObject.Find("bench").GetComponent<QueueBench>().BenchQueue.Dequeue();
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().creatineCount += 4;
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHcashToAdd;
                    timeVal = 0;
                    timerText.text = "";
                    i = i + 1;
                } catch {
                    agent.SetDestination(GameObject.Find("done").transform.position);
                    GameObject.Find("bench").GetComponent<QueueBench>().BenchQueue.Dequeue();
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().creatineCount += 4;
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHcashToAdd;
                    timeVal = 0;
                    timerText.text = "";
                }
            } else if (i == 4) {
                agent.SetDestination(GameObject.Find("done").transform.position);
                GameObject.Find("machine").GetComponent<QueueMachine>().MachineQueue.Dequeue();
                GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINEcashToAdd;
                timeVal = 0;
                timerText.text = "";
            }
        }
    }

    void EE() {
        timerText.text = "";
        for(int j = 0; j < Mathf.Floor(timeVal); j++) {
            timerText.text = timerText.text + "I";
        }
    }
}
