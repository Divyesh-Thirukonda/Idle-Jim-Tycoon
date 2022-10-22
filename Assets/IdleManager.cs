using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class IdleManager : MonoBehaviour
{
    public GameObject popup;
    public TextMeshProUGUI timeAwayText;
    public TextMeshProUGUI gainzText;
    public DateTime currentTime = DateTime.Now;
    public static bool gtg = true;
    public DateTime logOffDate;
    TimeSpan difference;


    public void LoadOfflineProduction() {
        if(gtg) {
            popup.SetActive(true);
            difference = currentTime-logOffDate;
            Debug.Log((difference.TotalSeconds).ToString() + "OHHH" + logOffDate);
            timeAwayText.text = "You were away for: " + ((int)difference.TotalSeconds).ToString() + " seconds...";
            gainzText.text = "...";
            StartCoroutine("waiter");
        }
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(1);
        gainzText.text = "and earned $" + (UIscript.cashPerSec * (int)difference.TotalSeconds).ToString();
        GameObject.Find("UIScript/CashStorage").GetComponent<UIscript>().cash += UIscript.cashPerSec * (int)difference.TotalSeconds;
    }

    void Start() {
        LoadOfflineProduction();
    }
}
