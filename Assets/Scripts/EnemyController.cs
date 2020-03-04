using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] [Range(1, 100)] private int health = 5;

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health <= 0)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Destroy(gameObject);
    }
}
