using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{
	public virtual void CardEffect(Card card, int numOfSymbol)
	{
		Debug.Log("card effect");
	}
}

class Attack : CardBehaviour
{
	public override void CardEffect(Card card, int numOfSymbol)
	{
		Debug.Log("number of " + card.ImageString + " symbols= " + numOfSymbol);
	}
}class Block : CardBehaviour
{
	public override void CardEffect(Card card, int numOfSymbol)
	{
		//apply 5 block to player
	}
}class Bleed : CardBehaviour
{
	public override void CardEffect(Card card, int numOfSymbol)
	{
		//deal 5 bleed to enemy
	}
}class Poison : CardBehaviour
{
	public override void CardEffect(Card card, int numOfSymbol)
	{
		//deal 5 poison to enemy
	}
}

