using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slots : MonoBehaviour
{
	public Reel[] spinningReels;
	public Reel[] resultReels;
	public GameObject[] slotGrid;

	public InputActionReference spin;
	bool startSpin;
	private DeckManager deckManager;
	private CardManager cardManager;

	private void Start()
	{
		deckManager = FindFirstObjectByType<DeckManager>();
		cardManager = GameManager.Instance.cardManager;
		startSpin = false;
	}

	private void OnEnable()
	{
		spin.action.started += SpinSlot;
	}
	private void OnDisable()
	{
		spin.action.started -= SpinSlot;
	}

	private void SpinSlot(InputAction.CallbackContext obj)
	{
		if (startSpin == false) { StartCoroutine(Spinning()); }
	}

	IEnumerator Spinning()
	{
		startSpin = true;

		foreach (Reel reel in spinningReels)
		{
			reel.spin = true;
			reel.EnableReel();
		}

		for (int i = 0; i < spinningReels.Length; i++)
		{
			yield return new WaitForSeconds(Random.Range(1, 3));
			spinningReels[i].spin = false;
		}
		foreach (Reel reel in spinningReels)
		{
			reel.DisableReel();
		}
		startSpin = false;
		GenerateResult();
		ResultCheck();
	}
	private void GenerateResult()
	{
		foreach (Reel reel in resultReels)
		{
			reel.RandomizeReel();
		}
	}
	private void ResultCheck()
	{
		List<Card> checkedCards = new List<Card>();

			foreach (Position position in resultReels[0].positionsInReel)
			{
				Card cardToCheck = position.card;
				if (resultReels[1].cardsInReel.Contains(cardToCheck) && checkedCards.Contains(cardToCheck) == false)
				{
					if (resultReels[2].cardsInReel.Contains(cardToCheck) && checkedCards.Contains(cardToCheck) == false)
					{
						checkedCards.Add(cardToCheck);
				}
				}
			}

		foreach(Card symbolsFound in checkedCards)
		{
			int symbolTotal = 0;
			foreach(Reel reel in resultReels)
			{
				int symbolInReel = reel.CheckSymbolInReel(symbolsFound);
				if (symbolInReel > 0)
				{
					symbolTotal += symbolInReel;
				}
			}
			if (symbolTotal > 0)
			{
				cardManager.ApplyBehaviour(symbolsFound, symbolsFound.actionType, symbolTotal);
			}
		}
	}
}
