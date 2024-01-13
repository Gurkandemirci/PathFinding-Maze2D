using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    // 201915032 - 201928011 - 201928022
    // Each maze has own MazeManager



    public Dictionary<Vector2, CellScript> allCells = new Dictionary<Vector2, CellScript>();
    

    void Start()
    {
        DefineAllCells();
    }


    // Add all children to dictionary and define color for start and finish point
    public void DefineAllCells()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            CellScript cell = transform.GetChild(i).gameObject.GetComponent<CellScript>();
            if (cell.isStartPoint)
            {
                cell.GetComponent<SpriteRenderer>().color = Color.green;
                cell.cellStatus = CellScript.CellStatus.visited;
            }
            if(cell.isFinishPoint)
                cell.GetComponent<SpriteRenderer>().color = Color.red;
            allCells.Add(cell.coord,cell);
        }
    }

    // Find neighbours according to wall activeness
    public List<CellScript> FindNeighbours(CellScript cell)
    {
        List<CellScript> neighbours = new List<CellScript>();


        if (!cell.isStartPoint)
        {
            cell.cellStatus = CellScript.CellStatus.visited;
            cell.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        CellScript neighbourCell;

        if (!cell.wallL.activeSelf)
        {
            neighbourCell = allCells[new Vector2(cell.coord.x - 1, cell.coord.y)];

            if(neighbourCell.cellStatus == CellScript.CellStatus.unvisited)
            {
                neighbourCell.cellStatus = CellScript.CellStatus.neighbour;
                if(!neighbourCell.isFinishPoint)
                {
                    neighbourCell.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                
                neighbours.Add(neighbourCell);
            }
            
        }

        if (!cell.wallR.activeSelf)
        {
            neighbourCell = allCells[new Vector2(cell.coord.x + 1, cell.coord.y)];
            if (neighbourCell.cellStatus == CellScript.CellStatus.unvisited)
            {
                neighbourCell.cellStatus = CellScript.CellStatus.neighbour;
                if (!neighbourCell.isFinishPoint)
                {
                    neighbourCell.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                neighbours.Add(neighbourCell);
            }
        }

        if (!cell.wallU.activeSelf)
        {
            neighbourCell = allCells[new Vector2(cell.coord.x, cell.coord.y + 1)];
            if (neighbourCell.cellStatus == CellScript.CellStatus.unvisited)
            {
                neighbourCell.cellStatus = CellScript.CellStatus.neighbour;
                if (!neighbourCell.isFinishPoint)
                {
                    neighbourCell.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                neighbours.Add(neighbourCell);
            }
        }

        if (!cell.wallD.activeSelf)
        {
            neighbourCell = allCells[new Vector2(cell.coord.x, cell.coord.y - 1)];
            if (neighbourCell.cellStatus == CellScript.CellStatus.unvisited)
            {
                neighbourCell.cellStatus = CellScript.CellStatus.neighbour;
                if (!neighbourCell.isFinishPoint)
                {
                    neighbourCell.GetComponent<SpriteRenderer>().color = Color.yellow;
                }
                neighbours.Add(neighbourCell);
            }
        }
        return neighbours;


    }
    
}
