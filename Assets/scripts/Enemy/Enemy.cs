using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public int Health;
    public int AttackPower;
    public int Mana;

    public Enemy(int health, int attackPower, int mana){
        
        Health = health;

        AttackPower = attackPower;

        Mana = mana;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
