using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TowerHealth playerTower;
    [SerializeField] private EnemySpawner enemyTower;
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        playerTower.onHealthChange = SetHealthText;
        enemyTower.onEnemySpawn = SetScoreText;
    }

    public void SetHealthText(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
    }

    public void SetScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}
