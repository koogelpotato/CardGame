using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardsBehaviour : MonoBehaviour {

	[SerializeField] private CardProperties cardProperties;
	private CardAssembler cardAssembler;
	public ZoneType zoneType { get { return cardAssembler.zoneType; } }
	private void  Awake()
    {
		cardAssembler = new CardAssembler(cardProperties);
		LoadInVisuals();
    }
	private void LoadInVisuals()
    {
		transform.GetChild(0).GetComponent<Image>().sprite = cardAssembler.cardImage;
		transform.GetChild(1).GetComponent<Text>().text = cardAssembler.cardName;
		transform.GetChild(2).GetComponent<Text>().text = cardAssembler.cardDescription;
	}
	
	private ZoneType ReturnCurrentZone(Transform parent)
    {
		ZoneType parentZone = parent.GetComponent<ZoneType>();
		return parentZone;
    }
	public CardType ReturnCardBeats()
    {
		return cardAssembler.cardBeats;
    }
	public CardType ReturnCardsBeatenBy()
    {
		return cardAssembler.cardGetsBeatenBy;
    }
	
}
