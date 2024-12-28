using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> CurrentEnemyList = new List<GameObject>();
    public FloorManager floorManager;
    public GameObject SecurityGuard;

    public Transform SpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        GameObject NewEnemy = Instantiate(SecurityGuard, SpawnPoint.position, SpawnPoint.rotation);

        NewEnemy.GetComponent<Enemy>().Initialize(100, -10, 10, 5, this.gameObject);
    }

    public void EnemyTurns()
    {
        foreach(GameObject gameObject in CurrentEnemyList){
            gameObject.GetComponent<Enemy>().RunTurn();
        }

        if(CurrentEnemyList.Count == 0){
            floorManager.UpdateBattleInt();
            LoadNewEnemies();
        }  
    }

    void LoadNewEnemies()
    {
        if(floorManager.canLoadNewEnemies()){
            //spawn new enemies or something
        }
    }
}


