using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> CurrentEnemyList = new List<GameObject>();

    public GameObject SecurityGuard;

    public Transform SpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnEnemy()
    {
        GameObject NewEnemy = Instantiate(SecurityGuard, SpawnPoint.position, SpawnPoint.rotation);

        NewEnemy.GetComponent<Enemy>().Initialize(100, -10, 10, 5);

        CurrentEnemyList.Add(NewEnemy);
    }

    void EnemyTurns()
    {
        foreach(GameObject gameObject in CurrentEnemyList){
            gameObject.GetComponent<Enemy>().RunTurn();
        }

    }

}


