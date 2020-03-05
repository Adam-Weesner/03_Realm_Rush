using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public delegate void OnEnemySpawn(int numEnemies);
    public OnEnemySpawn onEnemySpawn;

    [SerializeField] [Range(0.1f, 100.0f)] private float secondsBetweenSpawns = 2.0f;
    [SerializeField] private EnemyController enemyPrefab = null;
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform particlesParent;
    [SerializeField] private AudioClip spawnSFX;
    private bool isSpawning = true;
    private int numEnemies = 0;

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
            numEnemies++;
            onEnemySpawn.Invoke(numEnemies);
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
        }
    }
}
