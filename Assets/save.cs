using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System;

public class save : MonoBehaviour {

    void Start(){InvokeRepeating("SaveFile", 2f, 5f);}
    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if(File.Exists(destination)) {file = File.OpenWrite(destination);}
        else {file = File.Create(destination);}

        GameData data = new GameData(GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYtime, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLtime, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHtime, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINEtime, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYcashToAdd, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYlevel, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLcashToAdd, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLlevel, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHlevel, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHcashToAdd, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINElevel, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINEcashToAdd, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().acidCount, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().creatineCount, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().liquidCount, GameObject.Find("CheckClickScript").GetComponent<CheckClick>().hasbench, GameObject.Find("CheckClickScript").GetComponent<CheckClick>().hastread, GameObject.Find("CheckClickScript").GetComponent<CheckClick>().hasmachine, GameObject.Find("CheckClickScript").GetComponent<CheckClick>().haspharmacy, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().lobbySpotSave, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().treadSpotSave, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().benchSpotSave, GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().machineSpotSave, DateTime.Now, IdleManager.gtg);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();

        if(!IdleManager.gtg) IdleManager.gtg = true;
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if(File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYtime = data._LOBBYtime;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLtime = data._TREADMILLtime;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHtime = data._BENCHtime;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINEtime = data._MACHINEtime;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash = data._cash;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYcashToAdd = data._LOBBYcashToAdd;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().LOBBYlevel = data._LOBBYlevel;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLcashToAdd = data._TREADMILLcashToAdd;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().TREADMILLlevel = data._TREADMILLlevel;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHlevel = data._BENCHlevel;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().BENCHcashToAdd = data._BENCHcashToAdd;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINElevel = data._MACHINElevel;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().MACHINEcashToAdd = data._MACHINEcashToAdd;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().acidCount = data._acidCount;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().creatineCount = data._creatineCount;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().liquidCount = data._liquidCount;
        GameObject.Find("CheckClickScript").GetComponent<CheckClick>().hastread = data._hastread;
        GameObject.Find("CheckClickScript").GetComponent<CheckClick>().hasbench = data._hasbench;
        GameObject.Find("CheckClickScript").GetComponent<CheckClick>().hasmachine = data._hasmachine;
        GameObject.Find("CheckClickScript").GetComponent<CheckClick>().haspharmacy = data._haspharmacy;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().lobbySpotSave = data._lobbySpotSave;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().treadSpotSave = data._treadSpotSave;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().benchSpotSave = data._benchSpotSave;
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().machineSpotSave = data._machineSpotSave;
        GameObject.Find("Idle").GetComponent<IdleManager>().logOffDate = data._logOffDate;
        IdleManager.gtg = data._gtg;
    }
}