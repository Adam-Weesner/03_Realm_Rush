using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(1, 100)] public int damage = 5;
    [SerializeField] [Range(1, 100)] private int health = 5;
    [SerializeField] private ParticleSystem hitParticles = null;
    [SerializeField] private ParticleSystem deathParticles = null;
    [SerializeField] private ParticleSystem explodeParticles = null;
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

    public void OnExplode()
    {
        var vfx = Instantiate(explodeParticles, gameObject.transform);
        vfx.transform.SetParent(particlesParent);
        Destroy(gameObject);
    }
}
