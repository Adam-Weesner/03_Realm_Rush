using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isPlaceable = true;
    [HideInInspector] public bool isExplored = false;
    [HideInInspector] public Waypoint exploredFrom;
    private Vector2Int gridPos;
    private const int GRID_SIZE = 20;

    public int GetGridSize()
    {
        return GRID_SIZE;
    }

    public Vector2Int GetGridPos()
    {
        int x = Mathf.RoundToInt(transform.position.x / GRID_SIZE);
        int z = Mathf.RoundToInt(transform.position.z / GRID_SIZE);
        return new Vector2Int(x, z);
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            FindObjectOfType<TowerFactory>().AddTower(this);
        }
        else
        {
            print("Can't place here.");
        }
    }
}
