using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAssembler {

	
	public string cardName;
	
	public string cardDescription;
	
	public CardType cardType;
	
	public CardType cardBeats;
	
	public CardType cardGetsBeatenBy;
	
	public Sprite cardImage;

	public ZoneType zoneType;
	public CardAssembler(CardProperties cardProp)
    {
		cardName = cardProp.CardName;
		cardDescription = cardProp.CardDescription;
		cardType = cardProp.CardType;
		cardBeats = cardProp.CardBeats;
		cardGetsBeatenBy = cardProp.CardGetsBeatenBy;
		cardImage = cardProp.CardImage;
		zoneType = cardProp.ZoneType;
    }
}
