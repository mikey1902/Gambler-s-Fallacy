using TMPro;
using UnityEngine;

public class Position : MonoBehaviour
{
	public Card card;
	public TMP_Text positionText;

	private void Update()
	{
		if (card != null)
		{
			positionText.text = card.ImageString[0].ToString();
		}
	}
}
