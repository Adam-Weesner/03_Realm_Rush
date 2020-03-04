using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor: MonoBehaviour
{
    public TextMesh label;
    private Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }


    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        int x = waypoint.GetGridPos().x * gridSize;
        int z = waypoint.GetGridPos().y * gridSize;
    
        transform.position = new Vector3(x, 0.0f, z);
    }
    private void UpdateLabel()
    {
        int GRID_SIZE = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x + "," + waypoint.GetGridPos().y;
        if (label)
        {
            label.text = labelText;
            gameObject.name = "Cube: " + labelText;
        }
    }
}
