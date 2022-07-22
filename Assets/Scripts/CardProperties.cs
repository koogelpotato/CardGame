using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardProperties : ScriptableObject {

	[SerializeField]
	private string _cardName;
	[SerializeField]
	private string _cardDescription;
	[SerializeField]
	private CardType _cardType;
	[SerializeField]
	private CardType _cardBeats;
	[SerializeField]
	private CardType _cardGetsBeatenBy;
	[SerializeField]
	private Sprite _cardImage;
	[SerializeField]
	private ZoneType _zoneType;
	public string CardName { get { return _cardName; } }
	public string CardDescription { get { return _cardDescription; } }
	public CardType CardType { get { return _cardType; } }
	public CardType CardBeats { get { return _cardBeats; } }
	public CardType CardGetsBeatenBy { get { return _cardGetsBeatenBy; } }
	public Sprite CardImage { get { return _cardImage; } }
	public ZoneType ZoneType { get { return _zoneType; } }
}
