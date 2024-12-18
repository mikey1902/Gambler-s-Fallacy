using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{

    public string ImageString;

    public ActionType actionType;

    public int value;

    public enum ActionType
    {
        Attack,
        Defense,
        Utility,
    }
}
