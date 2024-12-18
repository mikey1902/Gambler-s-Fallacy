using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
	public List<Position> positionsInReel = new List<Position>();
	public bool spin;
	public int speed = 1500;
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

	void Update()
	{
		if (spin)
		{
			foreach (Transform img in transform)
			{
				img.transform.Translate(Vector2.down * Time.smoothDeltaTime * speed, Space.World);

				if (img.transform.position.y <= 0)
				{
					img.transform.position = new Vector2(img.transform.position.x, img.transform.position.y + 600);
				}
			}
		}
	}

	public void RandomizeReel()
	{
		for (int i = 0; i < positionsInReel.Count; i++)
		{
			int cardIndex = Random.Range(0, deckManager.rollingDeck.Count);
			positionsInReel[i].card = deckManager.rollingDeck[cardIndex];
			deckManager.RemoveCardFromRoll(cardIndex);
		}
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
