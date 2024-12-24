using UnityEngine;
using System.Collections.Generic;
using System;

public class CardManager : MonoBehaviour
{
	Dictionary<Card.ActionType, Type> behaviourMap = new Dictionary<Card.ActionType, Type>
	{
		{ Card.ActionType.ATTACK,  typeof(Attack)},
		{ Card.ActionType.BLOCK, typeof(Block)},
		{ Card.ActionType.BLEED, typeof(Bleed)},
		{ Card.ActionType.POISON, typeof(Poison)}
	};

	//can use for each when cards have multiple effects (ADD LATER IF DESIGNER IS BOZO LMAO *insert troll face*)
	//public void Add<CardBehaviour>(Card.ActionType action)
	//{
	//	switch (action)
	//	{
	//		case Card.ActionType.ATTACK:
	//			behaviourMap.Add(action, typeof(Attack));
	//			break;
	//		case Card.ActionType.BLOCK:
	//			behaviourMap.Add(action, typeof(Block));
	//			break;
	//		case Card.ActionType.BLEED:
	//			behaviourMap.Add(action, typeof(Bleed));
	//			break;
	//		case Card.ActionType.POISON:
	//			behaviourMap.Add(action, typeof(Poison));
	//			break;
	//	}
	//}

	public void ApplyBehaviour(Card card, Card.ActionType type, int numOfSymbol)
	{
		if (behaviourMap.ContainsKey(type))
		{
			CardBehaviour behaviour = (CardBehaviour)Activator.CreateInstance(behaviourMap[type]);
			behaviour.CardEffect(card, numOfSymbol);
			Destroy(behaviour);
		}
	}
}
