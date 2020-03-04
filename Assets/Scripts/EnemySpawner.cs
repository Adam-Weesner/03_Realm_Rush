using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 100.0f)] private float secondsBetweenSpawns = 2.0f;
    [SerializeField] private EnemyController enemyPrefab;
    private bool isSpawning = true;

    private void Start()
    {
        StartCoroutine(RepeatinglySpawnEnemy());
    }

    private IEnumerator RepeatinglySpawnEnemy()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(secondsBetweenSpawns);
            Instantiate(enemyPrefab, gameObject.transform);
        }
    }
}
