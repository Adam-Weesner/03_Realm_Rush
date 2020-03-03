using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor: MonoBehaviour
{
    [SerializeField] [Range(1, 20)] private int gridSize = 10;
    public TextMesh label;

    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x / 10.0f) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10.0f) * gridSize;

        transform.position = new Vector3(snapPos.x, 0.0f, snapPos.z);

        label.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
    }
}
