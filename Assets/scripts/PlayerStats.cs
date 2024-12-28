using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int currentHealth;
    public int MaxHealth;
    public EnemyManager enemyList;

    public void AlterHealth(int health)
    {
        currentHealth += health;
        Debug.Log("Current Health: " + currentHealth);
        CheckHealth();
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
