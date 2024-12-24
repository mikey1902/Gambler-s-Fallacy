using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public PlayerStats playerStats;
    public int CurrentHealth;
    public int MaxHealth;
    public int AttackPower;
    public int MaxMana;
    public int CurrentMana;
    public int ManaGain;
    public InputActionReference spin;
    public Slider slider;

    public void RunTurn(){

        CurrentMana += ManaGain;
        RefreshManaSlider();

        if(CurrentMana >= MaxMana)
        { 
            UseAbility();
            CurrentMana = 0;
            RefreshManaSlider();       
        }
    }

    private void RefreshManaSlider(){
        slider.value = CurrentMana;
    }

    public void Initialize(int health, int attackPower, int mana, int manaGain, GameObject enemyManager){
        
        CurrentHealth = health;
        
        MaxHealth = health;

        AttackPower = attackPower;

        MaxMana = mana;

        ManaGain = manaGain;

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        slider = GetComponentInChildren<Slider>();

        enemyManager.GetComponent<EnemyManager>().CurrentEnemyList.Add(gameObject);
    }

    
	private void OnEnable()
	{
		spin.action.started += TestAction;
	}
	private void OnDisable()
	{
		spin.action.started -= TestAction;
	}
	
	private void TestAction(InputAction.CallbackContext obj)
	{
		RunTurn();
	}
    public void UseAbility()
    {
        playerStats.AlterHealth(AttackPower);
    }

    public void takeDamage(int amount){

        CurrentHealth -= amount;

        if(CurrentHealth <= 0){
            Destroy(this.gameObject);
        }
    }
}
