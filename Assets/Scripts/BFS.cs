using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BFS : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022

    public MazeManager mazeManager;
    public Timer timer;
    Queue<CellScript> queue = new Queue<CellScript>();
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

        while(queue.Count != 0)
        {
            if (queue.Peek().isFinishPoint)
            {
                queue.Peek().GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            }
                
            queue.Peek().GetComponent<SpriteRenderer>().color = Color.magenta;
            yield return new WaitForSeconds(GameManager.instance.magentaWaitTime);
            List<CellScript> neighbours = mazeManager.FindNeighbours(queue.Dequeue());
            visitedCount++;
            AddToQueue(neighbours);

            yield return new WaitForSeconds(GameManager.instance.stepTime);
        }

        timer.StopTimer();
        timer.PrintElapsedTime("BFS", visitedCount);
        print("Visited cell count for BFS: " + visitedCount);
        yield return null;
    }

    public void AddFirstCell()
    {
        List<CellScript> neighbours = mazeManager.FindNeighbours(mazeManager.allCells[new Vector2(1, 1)]);
        AddToQueue(neighbours);
    }

    public void AddToQueue(List<CellScript> neighbours)
    {
        while(neighbours.Count != 0)
        {
            queue.Enqueue(neighbours[0]);
            neighbours.RemoveAt(0);
        }
        
    }
    
}
