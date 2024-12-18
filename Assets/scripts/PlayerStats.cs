using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int currentHealth;
    public int MaxHealth;

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
        currentHealth += Math.Max(health, 0);
        currentHealth = Math.Min(currentHealth, MaxHealth);
    }

    void CheckHealth(){
        if(currentHealth <= 0){
            Debug.Log("Game Over");
        }
    }
}
