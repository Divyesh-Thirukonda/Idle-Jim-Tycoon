using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIscript : MonoBehaviour
{
    public static float cashPerSec;

    public float LOBBYtime = 5;
    public float TREADMILLtime = 10;
    public float BENCHtime = 15;
    public float MACHINEtime = 20;

    public string lobbySpotSave = "t";
    public string treadSpotSave = "t";
    public string benchSpotSave = "t";
    public string machineSpotSave = "t";


    public float cash;
    public float LOBBYcashToAdd = 20;
    public float LOBBYlevel = 1;
    public float TREADMILLcashToAdd = 50;
    public float TREADMILLlevel = 1;
    public float BENCHlevel = 1;
    public float BENCHcashToAdd = 100;
    public float MACHINElevel = 1;
    public float MACHINEcashToAdd = 400;
    public float cashToSubtract;

    public TextMeshProUGUI CashText;
    public TextMeshProUGUI LobbyLevelText;
    public TextMeshProUGUI TreadmillLevelText;
    public TextMeshProUGUI BenchLevelText;
    public TextMeshProUGUI MachineLevelText;

    public float acidCount;
    public float creatineCount;
    public float liquidCount;
    public TextMeshProUGUI acidCountText;
    public TextMeshProUGUI creatineCountText;
    public TextMeshProUGUI liquidCountText;

    public TMP_InputField acidNameField;

    public GameObject[] lobbySpots;
    public GameObject[] treadSpots;
    public GameObject[] benchSpots;
    public GameObject[] machineSpots;

    void Start(){
        cashPerSec = ((LOBBYcashToAdd/LOBBYtime) + (TREADMILLcashToAdd/TREADMILLtime) + (BENCHcashToAdd/BENCHtime) + (MACHINEcashToAdd/MACHINEtime)) / 5;
        Debug.Log(cashPerSec);

        if(lobbySpotSave == "") {
            lobbySpotSave = "t";
        }
        if(treadSpotSave == "") {
            treadSpotSave = "t";
        }
        if(benchSpotSave == "") {
            benchSpotSave = "t";
        }
        if(machineSpotSave == "") {
            machineSpotSave = "t";
        }
        
        // Time.timeScale = 2;

        int l = 0;
        foreach (char ee in lobbySpotSave)
        {
            if(ee == 't') {
                lobbySpots[l].SetActive(true);
            }
            l++;
        }

        int t = 0;
        foreach (char ee in treadSpotSave)
        {
            if(ee == 't') {
                treadSpots[t].SetActive(true);
            }
            l++;
        }

        int b = 0;
        foreach (char ee in benchSpotSave)
        {
            if(ee == 't') {
                benchSpots[b].SetActive(true);
            }
            l++;
        }

        int m = 0;
        foreach (char ee in machineSpotSave)
        {
            if(ee == 't') {
                machineSpots[m].SetActive(true);
            }
            l++;
        }
    }

    void Awake(){
        GameObject.Find("SAVEANDLOAD").GetComponent<save>().LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        CashText.text = "$ " + UIupdate(cash);
        LobbyLevelText.text = "Level : " + UIupdate(LOBBYlevel);
        TreadmillLevelText.text = "Level : " + UIupdate(TREADMILLlevel);
        BenchLevelText.text = "Level : " + UIupdate(BENCHlevel);
        MachineLevelText.text = "Level : " + UIupdate(MACHINElevel);
        acidCountText.text = "Amino Acids : " + UIupdate(acidCount);
        creatineCountText.text = "Creatine : " + UIupdate(creatineCount);
        liquidCountText.text = "Liquids : " + UIupdate(liquidCount);

        if(isCounting) {
            timerAcidsMeth();
        }

        CashAddUpdate();
        TimeAddUpdate();
    }

    string UIupdate(float numToConvert) {
        string[] suffix = {"K", "M", "B", "T"};
        for(int i = 3; i >= 0; i--) {
            if (numToConvert < 1000) {
                return Mathf.Floor(numToConvert).ToString();
                break;
            }
            if(numToConvert / (1000 * Mathf.Pow(10, i*3)) > 1) {
                return Mathf.Floor(numToConvert / (1000 * Mathf.Pow(10, i*3))) + suffix[i];
                break;
            }
        }
        return "";
    }

    // make cashToSubtract increase but not so much that its impossible
    public void BuyItem(string itemName) {
        if(itemName == "lobby") {
            cashToSubtract = Mathf.Pow(LOBBYlevel, 2) * LOBBYcashToAdd;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                LOBBYcashToAdd += cashToSubtract*.7f;
                LOBBYlevel++;
                if(LOBBYlevel%10 == 0) {
                    LOBBYcashToAdd += cashToSubtract*1.4f;
                }
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        if(itemName == "treadmill") {
            cashToSubtract = Mathf.Pow(TREADMILLlevel, 2) * TREADMILLcashToAdd;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                TREADMILLcashToAdd += cashToSubtract*.7f;
                TREADMILLlevel++;
                if(TREADMILLlevel%10 == 0) {
                    TREADMILLcashToAdd += cashToSubtract*1.4f;
                }
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        if(itemName == "bench") {
            cashToSubtract = Mathf.Pow(BENCHlevel, 2) * BENCHcashToAdd;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                BENCHcashToAdd += cashToSubtract*.7f;
                BENCHlevel++;
                if(BENCHlevel%10 == 0) {
                    BENCHcashToAdd += cashToSubtract*1.4f;
                }
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        if(itemName == "machine") {
            cashToSubtract = Mathf.Pow(MACHINElevel, 2) * MACHINEcashToAdd;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                MACHINEcashToAdd += cashToSubtract*.7f;
                MACHINElevel++;
                if(MACHINElevel%10 == 0) {
                    MACHINEcashToAdd += cashToSubtract*1.4f;
                }
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        Debug.Log(cashToSubtract + " ohhh");
    }

    public TextMeshProUGUI lobbyProfCashAdd;
    public TextMeshProUGUI treadProfCashAdd;
    public TextMeshProUGUI benchProfCashAdd;
    public TextMeshProUGUI machineProfCashAdd;

    // make it equal to thins
    public void CashAddUpdate() {
        lobbyProfCashAdd.text = "$ " + (LOBBYlevel * 13).ToString();
        treadProfCashAdd.text = "$ " + (TREADMILLlevel * 50).ToString();
        benchProfCashAdd.text = "$ " + (BENCHlevel * 50).ToString();
        machineProfCashAdd.text = "$ " + (MACHINElevel * 50).ToString();
    }

    public TextMeshProUGUI lobbyTimeCashAdd;
    public TextMeshProUGUI treadTimeCashAdd;
    public TextMeshProUGUI benchTimeCashAdd;
    public TextMeshProUGUI machineTimeCashAdd;

    public void TimeAddUpdate() {
        lobbyTimeCashAdd.text = "$ " + (LOBBYlevel * 20).ToString();
        treadTimeCashAdd.text = "$ " + (TREADMILLlevel * 50).ToString();
        benchTimeCashAdd.text = "$ " + (BENCHlevel * 200).ToString();
        machineTimeCashAdd.text = "$ " + (MACHINElevel * 2000).ToString();

        if(maxl) {lobbyTimeCashAdd.text = "MAX";}
        if(maxt) {treadTimeCashAdd.text = "MAX";}
        if(maxb) {benchTimeCashAdd.text = "MAX";}
        if(maxm) {machineTimeCashAdd.text = "MAX";}
    }

    bool maxl;
    bool maxt;
    bool maxb;
    bool maxm;

    public void BuyTime(string itemName) {
        if(itemName == "lobby") {
            cashToSubtract = LOBBYlevel * 200;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                if(LOBBYtime > .5f) {
                    LOBBYtime -= .2f;
                } else {maxl = true;}
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        if(itemName == "treadmill") {
            cashToSubtract = TREADMILLlevel * 500;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                if(TREADMILLtime > .5f) {
                    TREADMILLtime -= .2f;
                } else {maxt = true;}
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        if(itemName == "bench") {
            cashToSubtract = BENCHlevel * 2000;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                if(BENCHtime > .5f) {
                    BENCHtime -= .2f;
                } else {maxb = true;}
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
        if(itemName == "machine") {
            cashToSubtract = MACHINElevel * 20000;
            if (cash - cashToSubtract >= 0) {
                cash -= cashToSubtract;
                if(MACHINEtime > .5f) {
                    MACHINEtime -= .2f;
                } else {maxm = true;}
            } else if (cash - cashToSubtract < 0) {
                Debug.Log("insufficient funds");
            }
        }
    }

    public void BuyPosition(GameObject objToActivate) {
        if(objToActivate.name[0] == 'l') {
            cashToSubtract = 3000;
        } else if(objToActivate.name[0] == 't') {
            cashToSubtract = 80000;
        } else if(objToActivate.name[0] == 'b') {
            cashToSubtract = 140000;
        } else if(objToActivate.name[0] == 'm') {
            cashToSubtract = 160000;
        }
        if (cash - cashToSubtract >= 0) {
            cash -= cashToSubtract;
            objToActivate.SetActive(true);
            // transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "BOUGHT"; // I don't think this is right dawg
            if(objToActivate.name[0] == 'l') {
                lobbySpotSave = lobbySpotSave + "t";
            } else if(objToActivate.name[0] == 't') {
                treadSpotSave = treadSpotSave + "t";
            } else if(objToActivate.name[0] == 'b') {
                benchSpotSave = benchSpotSave + "t";
            } else if(objToActivate.name[0] == 'm') {
                machineSpotSave = machineSpotSave + "t";
            }
        } else if (cash - cashToSubtract < 0) {
            Debug.Log("insufficient funds");
        }
    }

    IEnumerator startTimerRewards() {
        yield return new WaitForSeconds(100);
        Time.timeScale++;
    }

    public void CreateSpeed() {
        cashToSubtract = 40000;
        if (cash - cashToSubtract >= 0 && creatineCount - 50 >= 0 && liquidCount - 50 >= 0 && acidCount - 10 >= 0) {
            cash -= cashToSubtract;
            StartCoroutine("startTimerRewards");
        } else if (cash - cashToSubtract < 0 || creatineCount - 50 < 0 || liquidCount - 50 < 0 || acidCount - 10 < 0) {
            Debug.Log("insufficient funds");
        }
    }

    IEnumerator changeText(string textToChange) {
        GameObject.Find("HELPER").GetComponent<TextMeshProUGUI>().text = textToChange;

        yield return new WaitForSeconds(2);
        GameObject.Find("HELPER").GetComponent<TextMeshProUGUI>().text = "";
    }

    public float timeToRewards = 5;

    public string aminos = "arginine glycine methionine paolo tessari anna lante giuliano mosca lysine tryptophan alanine aspartic proline threonine glutamic leucine cysteine histidine isoleucine valine glutamine phenylalanine tyrosine serine asparagine";
    public string aminosFINAL = "arginine glycine methionine paolo tessari anna lante giuliano mosca lysine tryptophan alanine aspartic proline threonine glutamic leucine cysteine histidine isoleucine valine glutamine phenylalanine tyrosine serine asparagine";
    public void NamedAcid() {
        if(aminos.Contains(acidNameField.text) && isCounting) {
            aminos = aminos.Replace(acidNameField.text, "");
            acidCount++;
            StartCoroutine("changeText", "Correct!");
        }
    }

    public bool isCounting;
    public float timerAcids = 30f;

    void timerAcidsMeth() {
        float preTimeScale = Time.timeScale;
        Time.timeScale = 1;
        timerAcids -= Time.deltaTime;
        if(timerAcids <= 0) {
            timerAcids = 30f;
            aminos = aminosFINAL;
            Time.timeScale = preTimeScale;
            StartCoroutine("changeText", "Time is up! You can press back now");
            isCounting = false;
        }

    }

    public void StartTimerAcids() {
        isCounting = true;
    }


}
