using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private Vector2Int gridPos;
    private const int GRID_SIZE = 10;

    public int GetGridSize()
    {
        return GRID_SIZE;
    }

    public Vector2Int GetGridPos()
    {
        int x = Mathf.RoundToInt(transform.position.x / GRID_SIZE) * GRID_SIZE;
        int z = Mathf.RoundToInt(transform.position.z / GRID_SIZE) * GRID_SIZE;
        return new Vector2Int(x, z);
    }
}
