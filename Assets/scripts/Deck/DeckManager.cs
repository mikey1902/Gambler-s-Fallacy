using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
public class DeckManager : MonoBehaviour
{

    public object[] cards;
    public Dictionary<string, int> symbolOdds = new Dictionary<string, int>
    {
        { "tenImage", 22 },
        { "jackImage", 20 },
        { "queenImage", 18 },
        { "kingImage", 18 },
        { "aceImage", 15 },
        { "scatterImage", 7 },
        { "wildcardImage", 0},
        { "uniqueImage", 0}
    };
    private System.Random random = new System.Random();

    void Start()
    {
        cards = Resources.LoadAll("Cards", typeof(Card));
        RefreshOdds();
    }

    void RefreshOdds()
    {
        symbolOdds = new Dictionary<string, int>
        {
            { "tenImage", 22 },
            { "jackImage", 20 },
            { "queenImage", 18 },
            { "kingImage", 18 },
            { "aceImage", 15 },
            { "scatterImage", 7 },
            { "wildcardImage", 0},
            { "uniqueImage", 0}
        };
    }

    public Card  GetRandomIcon()
    {
        List<KeyValuePair<string
        , int>> cumulativeOdds = new List<KeyValuePair<string, int>>();
        int cumulativeSum = 0;

        foreach (var symbol in symbolOdds)
        {
            cumulativeSum += symbol.Value;
            cumulativeOdds.Add(new KeyValuePair<string, int>(symbol.Key, cumulativeSum));
        }

        int randomNumber = random.Next(1, cumulativeSum + 1);

        foreach (var symbol in cumulativeOdds)
        {
            if (randomNumber <= symbol.Value)
            {
                return GetCardByName(symbol.Key);
            }
        }

        return GetCardByName("tenImage");
    }

    public Card GetCardByName(string name)
    {
        foreach (var card in cards)
        {
            if (card is Card cardObject && cardObject.ImageString == name)
            {
                return cardObject;
            }
        }
        return null; // Return null if no match is found
    }


    public void AdjustOdds(string cardName, int increaseAmount)
    {
        symbolOdds[cardName] += increaseAmount;

        int totalOdds = 0;
        foreach (var odds in symbolOdds.Values)
        {
            totalOdds += odds;
        }

        if (totalOdds > 100)
        {
            int excess = totalOdds - 100;

            List<string> keysToAdjust = new List<string>();
            foreach (var key in symbolOdds.Keys)
            {
                if (key != cardName)
                {
                    keysToAdjust.Add(key);
                }
            }

            int reductionPerCard = excess / keysToAdjust.Count;
            foreach (var key in keysToAdjust)
            {
                int newOdds = symbolOdds[key] - reductionPerCard;
                symbolOdds[key] = Mathf.Max(newOdds, 0);
            }
        }
        LogSymbolOdds();
    }
    public void LogSymbolOdds()
    {
        Debug.Log("Symbol Odds:");
        foreach (var symbol in symbolOdds)
        {
            Debug.Log($"{symbol.Key}: {symbol.Value}%");
        }
    }

}
