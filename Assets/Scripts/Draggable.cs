using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	[HideInInspector]
	public Transform parentToReturnTo = null;
	[HideInInspector]
	public Transform placeHolderParent = null;
	private GameObject placeHolder = null;
	[SerializeField]
	public List<ZoneType> AllowedZones;
	public ZoneType initialZone { get; private set; }
	public ZoneType currentZone { get; private set; }
	public void Start()
    {
		initialZone = ReturnZone();
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		placeHolder = new GameObject();
		placeHolder.transform.SetParent(this.transform.parent);
		LayoutElement le = placeHolder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleHeight = 0;
		le.flexibleWidth = 0;

		placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
		parentToReturnTo = this.transform.parent;
		placeHolderParent = parentToReturnTo;
		this.transform.SetParent(this.transform.parent.parent);
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData eventData)
    {
		int newSiblingIndex = placeHolderParent.childCount;
		this.transform.position = eventData.position;
		if (placeHolder.transform.parent != placeHolderParent)
			placeHolder.transform.SetParent(placeHolderParent);
		for(int i = 0; i < placeHolderParent.childCount; i++)
        {
			
			if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
            {
				newSiblingIndex = i;
				if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                {
					newSiblingIndex--;
                }
				break;
            }
        }
		placeHolder.transform.SetSiblingIndex(newSiblingIndex);
    }
	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(parentToReturnTo);
		this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		Destroy(placeHolder);
		currentZone = ReturnZone();
		DrawCard();
	}
	
	
	private ZoneType ReturnZone()
    {
		ZoneType Zone = transform.parent.GetComponent<DropZone>()._zoneType;
		return Zone;
    }

	private void DrawCard()
    {
		if(initialZone != currentZone)
        {
			GameManager.Instance.UpdateGameState(GameManager.GameState.EnemyDrawCard); 
        }
    }
	private void DisableCardDrag()
    {
		Draggable drag = this.GetComponent<Draggable>();
		drag.enabled = false;
    }
	
}
