using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float waitTime = 1.0f;
    private Vector3 nextWaypointPos;

    private void Start()
    {
        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, nextWaypointPos, Time.deltaTime);
    }

    private IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            var newPos = waypoint.transform.position;
            nextWaypointPos = new Vector3(newPos.x, 20, newPos.z);
            
            yield return new WaitForSeconds(waitTime);
        }
    }
}
