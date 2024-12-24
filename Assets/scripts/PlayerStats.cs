using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int currentHealth;
    public int MaxHealth;
    public EnemyManager enemyList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AlterHealth(int health)
    {
        currentHealth += health;
        Debug.Log("Current Health: " + currentHealth);
        CheckHealth();
        StartPlayerTurn(30);
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    public void StartPlayerTurn(int amount)
    {

        if (amount > 0)
        {
            Enemy temp = enemyList.CurrentEnemyList[0].GetComponent<Enemy>();

            temp.takeDamage(amount);
        }

    }


}
