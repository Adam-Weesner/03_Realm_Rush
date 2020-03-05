using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public delegate void OnHealthChange(int health);
    public OnHealthChange onHealthChange;
    [SerializeField] private AudioClip damageSFX;
    [SerializeField] [Range(1, 500)] private int health = 50;

    private void Start()
    {
        onHealthChange.Invoke(health);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponentInParent<EnemyController>();

        if (!enemy) { return; }

        health -= enemy.damage;

        onHealthChange.Invoke(health);

        GetComponent<AudioSource>().PlayOneShot(damageSFX);
    }
}
