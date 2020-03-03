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
        int GRID_SIZE = waypoint.GetGridSize();
        int x = waypoint.GetGridPos().x;
        int z = waypoint.GetGridPos().y;
    
        transform.position = new Vector3(x, 0.0f, z);
    }
    private void UpdateLabel()
    {
        int GRID_SIZE = waypoint.GetGridSize();
        string labelText = waypoint.GetGridPos().x / GRID_SIZE + "," + waypoint.GetGridPos().y / GRID_SIZE;
        label.text = labelText;
        gameObject.name = "Cube: " + labelText;
    }
}
