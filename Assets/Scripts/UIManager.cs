using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022
    // It print name, elapsed time and visited count to screen.

    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public TMP_Text[] rankNames;
    public TMP_Text[] rankMinutes;
    public TMP_Text[] rankVisitedNodes;
    public int rankCounter = 0;
    

    public void SetActiveFalseButton(GameObject button)
    {
        button.SetActive(false);
    }

    public void WriteTextAccordingToText(string algName, int visitedCount, int minutes, int seconds)
    {
        rankNames[rankCounter].text = algName;
        rankMinutes[rankCounter].text = string.Format("{0:00}:{1:00}", minutes, seconds) + " minutes ";
        rankVisitedNodes[rankCounter].text = visitedCount + " visited nodes";
        rankCounter++;
    }

}
