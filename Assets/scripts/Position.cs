using TMPro;
using UnityEngine;

public class Position : MonoBehaviour
{
	public Card card;
	public TMP_Text positionText;
	private CardManager cardManager;

	void Start()
	{
		cardManager = GameManager.Instance.CardManager;
	}

	private void Update()
	{
		if (card != null)
		{
			positionText.text = card.ImageString[0].ToString().ToUpper();
		}
	}

	//public void AddBehaviour()
	//{
		//cardManager.Add<CardBehaviour>(card.actionType);
	//}
}
