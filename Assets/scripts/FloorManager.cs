using UnityEngine;

public class FloorManager : MonoBehaviour
{
    private int BattleEncountersMax;
    private int CurrentEncounterNum;
    private int FloorNumber;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FloorNumber = 0;
        CurrentEncounterNum = Random.Range(3,7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBattleInt(){
        
        if(CurrentEncounterNum != BattleEncountersMax){
        CurrentEncounterNum++;    
        }
        else{
            //code for shop/boss
        }
    }

    public bool canLoadNewEnemies()
    {
        if(CurrentEncounterNum != BattleEncountersMax)
        {
            return true;
        }
        return false;
    }

    public void UpdateFloorNumber(){
        FloorNumber++;
    }
}
