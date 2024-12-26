using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
	public List<Position> positionsInReel = new List<Position>();
	public List<Card> cardsInReel = new List<Card>();
	public bool spin;
	public int speed = 4000;
	public DeckManager deckManager;

	void Start()
	{
		spin = false;
		deckManager = FindFirstObjectByType<DeckManager>();

		foreach (Transform img in transform)
		{
			positionsInReel.Add(img.gameObject.GetComponent<Position>());
		}
	}

	void FixedUpdate()
	{
		if (spin)
		{
			foreach (Transform img in transform)
			{
				img.transform.Translate(Vector2.down * Time.smoothDeltaTime * speed, Space.World);

				if (img.transform.position.y <= 0)
				{
					img.transform.position = new Vector2(img.transform.position.x, img.transform.position.y + 800);
				}
			}
		}
	}

	public void RandomizeReel()
	{
		//randomizes icons the the reels
		Debug.Log(deckManager.GetRandomIcon());
		for (int i = 0; i < positionsInReel.Count; i++)
		{
			positionsInReel[i].card = deckManager.GetRandomIcon();
		}
		//saves the icons to list
		foreach (Position position in positionsInReel)
		{
			cardsInReel.Add(position.card);
		}
	}
	public int CheckSymbolInReel(Card card)
	{
		int numOfSymbol = 0;
		foreach(Card cardInReel in cardsInReel)
		{
			if(cardInReel == card)
			{
				numOfSymbol += 1;
			}
		}
		return numOfSymbol;
	}
	public void EnableReel()
	{
		gameObject.SetActive(true);
	}
	public void DisableReel()
	{
		gameObject.SetActive(false);
	}
}
