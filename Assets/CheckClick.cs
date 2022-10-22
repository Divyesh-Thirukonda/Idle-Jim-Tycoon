using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClick : MonoBehaviour
{
    public GameObject LobbyUI;
    public GameObject TreadmillUI;
    public GameObject BenchUI;
    public GameObject MachineUI;
    public GameObject PharmacyUI;

    public bool hasbench;
    public bool hastread;
    public bool hasmachine;
    public bool haspharmacy;

    void Start() {
        if(hasbench){
            GameObject.Find("BenchPriceText").SetActive(false);
            GameObject.Find("BenchOBJ").transform.GetChild(0).gameObject.SetActive(true);
        }
        if(hastread) {
            GameObject.Find("TreadmilllllPriceText").SetActive(false);
            GameObject.Find("TreadOBJ").transform.GetChild(0).gameObject.SetActive(true);
        }
        if(hasmachine) {
            GameObject.Find("MachinePriceText").SetActive(false);
            GameObject.Find("MachineOBJ").transform.GetChild(0).gameObject.SetActive(true);
        }
        if(haspharmacy) {
            GameObject.Find("PharmacyPriceText").SetActive(false);
            GameObject.Find("PharmacyOBJ").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hitInfo)) {
                if (hitInfo.collider.gameObject.tag == "Stand") {
                    OpenStandUI(hitInfo.collider.gameObject.name);
                }
                if(hitInfo.collider.gameObject.name == "WALKABLE (4)") {
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract = 100;
                    if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract >= 0) {
                        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash -= GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract;
                        GameObject.Find("TreadmilllllPriceText").SetActive(false);
                        GameObject.Find("TreadOBJ").transform.GetChild(0).gameObject.SetActive(true);
                        hastread = true;
                    } else if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract < 0) {
                        Debug.Log("insufficient funds");
                    }
                }
                if(hitInfo.collider.gameObject.name == "WALKABLE (5)") {
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract = 1000;
                    if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract >= 0) {
                        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash -= GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract;
                        GameObject.Find("BenchPriceText").SetActive(false);
                        GameObject.Find("BenchOBJ").transform.GetChild(0).gameObject.SetActive(true);
                        hasbench = true;
                    } else if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract < 0) {
                        Debug.Log("insufficient funds");
                    }
                }
                if(hitInfo.collider.gameObject.name == "WALKABLE (6)") {
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract = 10000;
                    if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract >= 0) {
                        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash -= GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract;
                        GameObject.Find("MachinePriceText").SetActive(false);
                        GameObject.Find("MachineOBJ").transform.GetChild(0).gameObject.SetActive(true);
                        hasmachine = true;
                    } else if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract < 0) {
                        Debug.Log("insufficient funds");
                    }
                }
                if(hitInfo.collider.gameObject.name == "WALKABLE (7)") {
                    GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract = 2000;
                    if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract >= 0) {
                        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash -= GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract;
                        GameObject.Find("PharmacyPriceText").SetActive(false);
                        GameObject.Find("PharmacyOBJ").transform.GetChild(0).gameObject.SetActive(true);
                        haspharmacy = true;
                    } else if (GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash - GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cashToSubtract < 0) {
                        Debug.Log("insufficient funds");
                    }
                }
            }
        }
    }

    void OpenStandUI(string nameOfStand) {
        if(nameOfStand == "lobby") {
            OpenLobbyUI();
        }
        if(nameOfStand == "treadmill") {
            OpenTreadmillUI();
        }
        if(nameOfStand == "bench") {
            OpenBenchUI();
        }
        if(nameOfStand == "machine") {
            OpenMachineUI();
        }
        if(nameOfStand == "pharmacy") {
            OpenPharmacyUI();
        }
    }

    void OpenLobbyUI() {
        LobbyUI.SetActive(true); // Open panel
    }
    void OpenTreadmillUI() {
        TreadmillUI.SetActive(true); // Open panel
    }
    void OpenBenchUI() {
        BenchUI.SetActive(true); // Open panel
    }
    void OpenMachineUI() {
        MachineUI.SetActive(true); // Open panel
    }
    void OpenPharmacyUI() {
        PharmacyUI.SetActive(true); // Open panel
    }
}
