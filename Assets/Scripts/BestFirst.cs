using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestFirst : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022

    public MazeManager mazeManager;
    public Timer timer;
    MyPriorityQueue<CellScript> pQueue = new MyPriorityQueue<CellScript>();
    public int visitedCount = 0;


    // Start algorithm
    public void StartButton()
    {
        mazeManager = transform.GetChild(0).GetComponent<MazeManager>();
        timer = GetComponent<Timer>();

        AddFirstCell();
        StartCoroutine(SolveMaze());
    }

    IEnumerator SolveMaze()
    {
        timer.StartTimer();

        while (pQueue.Count != 0)
        {
            if (pQueue.Peek().isFinishPoint)
            {
                pQueue.Peek().GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            }
            pQueue.Peek().GetComponent<SpriteRenderer>().color = Color.magenta;
            yield return new WaitForSeconds(GameManager.instance.magentaWaitTime);
            List<CellScript> neighbours = mazeManager.FindNeighbours(pQueue.Dequeue());
            visitedCount++;
            AddToQueue(neighbours);

            yield return new WaitForSeconds(GameManager.instance.stepTime);
        }

        timer.StopTimer();
        timer.PrintElapsedTime("Best First", visitedCount);
        print("Visited cell count for Best First: " + visitedCount);
        yield return null;
    }

    public void AddFirstCell()
    {
        List<CellScript> neighbours = mazeManager.FindNeighbours(mazeManager.allCells[new Vector2(1, 1)]);
        AddToQueue(neighbours);
    }

    public void AddToQueue(List<CellScript> neighbours)
    {
        while (neighbours.Count != 0)
        {
            pQueue.Enqueue(neighbours[0],neighbours[0].manhattanDistance);
            neighbours.RemoveAt(0);
        }

    }

}
