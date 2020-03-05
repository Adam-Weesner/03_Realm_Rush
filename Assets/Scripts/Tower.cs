using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan = null;
    [SerializeField] private ParticleSystem bullets = null;
    [SerializeField] [Range(0, 500)] private int attackRange = 50;
    [SerializeField] private AudioClip shootSFX;
    [HideInInspector] public Waypoint baseWaypoint;
    private Transform targetEnemy = null;
    private ParticleSystem.EmissionModule emission;

    private void Start()
    {
        emission = bullets.emission;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        TargetEnemy();
    }

    private void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyController>();

        if (sceneEnemies.Length == 0) { return; }

        Transform closestEnemy = sceneEnemies[0].transform;

        foreach (EnemyController testEnemy in sceneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform enemyA, Transform enemyB)
    {
        var distanceToEnemyA = Vector3.Distance(enemyA.position, objectToPan.position);
        var distanceToEnemyB = Vector3.Distance(enemyB.position, objectToPan.position);

        if (distanceToEnemyA < distanceToEnemyB)
        {
            return enemyA;
        }

        return enemyB;
    }

    private void TargetEnemy()
    {
        if (targetEnemy)
        {
            var distanceToEnemy = Vector3.Distance(targetEnemy.position, objectToPan.position);

            if (distanceToEnemy <= attackRange)
            {
                Shoot(true);
            }
            else
            {
                Shoot(false);
            }
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isShooting = true)
    {
        if (isShooting)
        {
            objectToPan.LookAt(targetEnemy);
            emission.enabled = true;
        }
        else
        {
            emission.enabled = false;
        }
    }
}
