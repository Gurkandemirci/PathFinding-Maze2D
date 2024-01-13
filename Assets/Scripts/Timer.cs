using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;


public class Timer : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022
    // Each algorithm has own Timer. It keeps elapsed time for own algorithm.
    

    public Stopwatch timer = new Stopwatch();

    public void StartTimer()
    {
        timer.Start();
    }

    public void StopTimer()
    {
        timer.Stop();
    }

    // It return all information to UIManager
    public void PrintElapsedTime(string algName, int visitedCount)
    {
        UIManager.instance.WriteTextAccordingToText(algName, visitedCount, timer.Elapsed.Minutes, timer.Elapsed.Seconds);
    }
}
