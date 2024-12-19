using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private PlayerStats playerStats;
    public int Health;
    public int AttackPower;
    public int MaxMana;
    public int CurrentMana;
    public int ManaGain;

    public void RunTurn(){

        CurrentMana += ManaGain;

        if(CurrentMana >= MaxMana)
        {
            UseAbility();
        }
    }

    public void Initialize(int health, int attackPower, int mana, int manaGain){
        
        Health = health;

        AttackPower = attackPower;

        MaxMana = mana;

        ManaGain = manaGain;
    }

    public void UseAbility()
    {
        playerStats.AlterHealth(AttackPower);
    }
}
