using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 100.0f)] private float secondsBetweenSpawns = 2.0f;
    [SerializeField] private EnemyController enemyPrefab = null;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform particlesParent;
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
            var newEnemy = Instantiate(enemyPrefab, gameObject.transform);
            newEnemy.transform.SetParent(enemyParent);
            newEnemy.particlesParent = particlesParent;
        }
    }
}
