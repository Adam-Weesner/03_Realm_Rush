using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] [Range(1, 100)] private int health = 5;
    [SerializeField] private ParticleSystem hitParticles = null;
    [SerializeField] private ParticleSystem deathParticles = null;
    [HideInInspector] public Transform particlesParent;

    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health <= 0)
        {
            OnDeath();
        } 
        else
        {
            hitParticles.Play();
        }
    }

    private void OnDeath()
    {
        var vfx = Instantiate(deathParticles, gameObject.transform);
        vfx.transform.SetParent(particlesParent);
        Destroy(gameObject);
    }
}
