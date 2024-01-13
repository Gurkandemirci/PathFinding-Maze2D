using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022
    // Each cell has own CellScript. It keeps information about this cell.

    public GameObject wallL;
    public GameObject wallR;
    public GameObject wallU;
    public GameObject wallD;

    public bool isStartPoint;
    public bool isFinishPoint;

    public Vector2 coord;

    public int manhattanDistance;

    public CellStatus cellStatus;

    public enum CellStatus
    {
        unvisited,
        visited,
        neighbour
    }
}