using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isPlaceable = true;
    [SerializeField] private Tower towerPrefab = null;
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
            PlaceTower();
        }
        else
        {
            print("Can't place here.");
        }
    }

    private void PlaceTower()
    {
        var newTower = Instantiate(towerPrefab, gameObject.transform);
        newTower.transform.position = new Vector3(newTower.transform.position.x, 20, newTower.transform.position.z);
        newTower.transform.SetParent(GameObject.Find("Towers").transform);
        isPlaceable = false;
    }
}
