using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeckManager : MonoBehaviour
{

    private Object[] cards;
    public List<Card> staticDeck = new List<Card>();

    /// <summary>
    /// Use rollingDeck to generate the roll with, 
    /// delete cards that are chosen for the reals so they arent used in subsequent reals. 
    /// before every roll, use RefreshDeck to reset rollingDeck for the roll and any updated cards from the shop or broken cards etc.
    /// </summary>
    public List<Card> rollingDeck = new List<Card>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateNewDeck();
    }

    void CreateNewDeck()
    {
        cards = Resources.LoadAll("Cards", typeof(Card));

        foreach (Card card in cards)
        {
            switch (card.ImageString)
            {
                case "tenImage":
                    for (int i = 0; i <= 25; i++)
                    {
                        staticDeck.Add(card);
                    }
                    break;
                case "jackImage":
                    for (int i = 0; i <= 20; i++)
                    {
                        staticDeck.Add(card);
                    }
                    break;
                case "queenImage":
                    for (int i = 0; i <= 15; i++)
                    {
                        staticDeck.Add(card);
                    }
                    break;
                case "kingImage":
                    for (int i = 0; i <= 15; i++)
                    {
                        staticDeck.Add(card);
                    }
                    break;
                case "aceImage":
                    for (int i = 0; i <= 10; i++)
                    {
                        staticDeck.Add(card);
                    }
                    break;
                case "scatterImage":

                    for (int i = 0; i <= 3; i++)
                    {
                        staticDeck.Add(card);
                    }
                    break;
            }
        }
    }

    void AddCardToDeck(Card card)
    {
        staticDeck.Add(card);
    }

    void RemoveCardFromDeck(Card card)
    {
        staticDeck.Remove(card);
    }

    public void RefreshDeck()
    {
        rollingDeck = staticDeck;
    }
}
