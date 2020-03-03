using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> path;
    [SerializeField] private float waitTime = 1.0f;

    private void Start()
    {
        //StartCoroutine(PrintAllWaypoints());
    }

    private IEnumerator PrintAllWaypoints()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
