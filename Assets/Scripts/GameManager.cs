using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022
    // Copy generated maze for all algorithms 

    public static GameManager instance;
    public Transform[] algorithmPanels;
    public float stepTime = 0;
    public float magentaWaitTime = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   

    public void DefineMazeToFirstPanel(Transform mazeParent)
    {
        mazeParent.parent = algorithmPanels[0];
        mazeParent.transform.localPosition = Vector2.zero;
        DefineOtherMazesToPanels(mazeParent);
    }

    public void DefineOtherMazesToPanels(Transform mazeParent)
    {
        for(int i = 1; i < algorithmPanels.Length; i++)
        {
            GameObject mazeCopy = Instantiate(mazeParent.gameObject);
            mazeCopy.transform.parent = algorithmPanels[i];
            mazeCopy.transform.localPosition = Vector2.zero;
        }
    }


}
