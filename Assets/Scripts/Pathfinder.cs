using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Pathfinder : MonoBehaviour
{
    [SerializeField] private Waypoint startWaypoint = null;
    [SerializeField] private Waypoint endWaypoint = null;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    private Waypoint searchCenter;
    [HideInInspector] public List<Waypoint> path = new List<Waypoint>();
    private Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        PathFind();
        CreatePath();
        return path;
    }

    private void CreatePath()
    {
        Waypoint previous = endWaypoint;
        while (previous)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Reverse();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            print("Searching from: " + searchCenter);

            if (searchCenter == endWaypoint)
            {
                print("Found end at: " + endWaypoint.GetGridPos());
                break;
            }

            ExploreNeighbors();
        }
    }

    private void ExploreNeighbors()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int explorationCoor = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(explorationCoor))
            {
                QueueNewNeighbor(explorationCoor);
            }
        }
    }

    private void QueueNewNeighbor(Vector2Int explorationCoor)
    {
        Waypoint neighbor = grid[explorationCoor];
        if (!neighbor.isExplored && !queue.Contains(neighbor))
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                Debug.LogWarning("Overlapping block at: " + waypoint.GetGridPos());
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }
    }
}
