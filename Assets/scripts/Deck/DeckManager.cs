using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
public class DeckManager : MonoBehaviour
{

    public Dictionary<string, int> symbolOdds = new Dictionary<string, int>
    {
        { "Ten", 22 },
        { "Jack", 20 },
        { "Queen", 18 },
        { "King", 18 },
        { "Ace", 15 },
        { "Scatter", 7 }
    };
    private System.Random random = new System.Random();

    void Start()
    {
        RefreshOdds();
    }

    void RefreshOdds()
    {
        symbolOdds = new Dictionary<string, int>
        {
            { "Ten", 22 },
            { "Jack", 20 },
            { "Queen", 18 },
            { "King", 18 },
            { "Ace", 15 },
            { "Scatter", 7 }
        };
    }

    public string GetRandomIcon()
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
                return symbol.Key;
            }
        }

        return null;
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
