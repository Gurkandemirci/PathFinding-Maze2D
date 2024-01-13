using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSearch : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022

    public MazeManager mazeManager;
    public Timer timer;
    List<CellScript> neighbourList = new List<CellScript>();
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

        while (neighbourList.Count != 0)
        {
            int randomNumber = Random.Range(0, neighbourList.Count);
            if (neighbourList[randomNumber].isFinishPoint)
            {
                neighbourList[randomNumber].GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            }
            neighbourList[randomNumber].GetComponent<SpriteRenderer>().color = Color.magenta;
            yield return new WaitForSeconds(GameManager.instance.magentaWaitTime);
            List<CellScript> neighbours = mazeManager.FindNeighbours(neighbourList[randomNumber]);
            neighbourList.RemoveAt(randomNumber);
            visitedCount++;
            AddToList(neighbours);

            yield return new WaitForSeconds(GameManager.instance.stepTime);
        }

        timer.StopTimer();
        timer.PrintElapsedTime("Random Search",visitedCount);
        print("Visited cell count for DFS: " + visitedCount);
        yield return null;
    }

    public void AddFirstCell()
    {

        List<CellScript> neighbours = mazeManager.FindNeighbours(mazeManager.allCells[new Vector2(1, 1)]);
        AddToList(neighbours);
    }

    public void AddToList(List<CellScript> neighbours)
    {
        while (neighbours.Count != 0)
        {
            neighbourList.Add(neighbours[0]);
            neighbours.RemoveAt(0);
        }

    }
}
