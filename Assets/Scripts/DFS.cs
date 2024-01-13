using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DFS : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022

    public MazeManager mazeManager;
    public Timer timer;
    Stack<CellScript> stack = new Stack<CellScript>();
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

        while (stack.Count != 0)
        {
            if (stack.Peek().isFinishPoint)
            {
                stack.Peek().GetComponent<SpriteRenderer>().color = Color.cyan;
                break;
            }
            stack.Peek().GetComponent<SpriteRenderer>().color = Color.magenta;
            yield return new WaitForSeconds(GameManager.instance.magentaWaitTime);
            List<CellScript> neighbours = mazeManager.FindNeighbours(stack.Pop());
            visitedCount++;
            AddToStack(neighbours);

            yield return new WaitForSeconds(GameManager.instance.stepTime);
        }

        timer.StopTimer();
        timer.PrintElapsedTime("DFS", visitedCount);
        print("Visited cell count for DFS: " + visitedCount);
        yield return null;
    }

    public void AddFirstCell()
    {
        List<CellScript> neighbours = mazeManager.FindNeighbours(mazeManager.allCells[new Vector2(1, 1)]);
        AddToStack(neighbours);
    }

    public void AddToStack(List<CellScript> neighbours)
    {
        while (neighbours.Count != 0)
        {
            stack.Push(neighbours[0]);
            neighbours.RemoveAt(0);
        }

    }

}