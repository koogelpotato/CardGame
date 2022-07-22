using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public ZoneType _zoneType;
    private void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerEnter.GetComponent<Draggable>();
        if (d != null)
        {
            d.placeHolderParent = this.transform;
        }
    }
    private void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable d = eventData.pointerEnter.GetComponent<Draggable>();
        if (d != null && d.placeHolderParent == this.transform)
        {
            d.placeHolderParent = d.parentToReturnTo;
        }
    }
	public void OnDrop(PointerEventData eventData)
    {
       
        Draggable drag = eventData.pointerDrag.GetComponent<Draggable>();
        if (drag != null && CheckAllowedZone(eventData))
        {
            drag.parentToReturnTo = this.transform;
        }
        
    }
    private bool CheckAllowedZone(PointerEventData data)
    {
        Draggable drag = data.pointerDrag.GetComponent<Draggable>();
        foreach(var zone in drag.AllowedZones)
        {
            if (_zoneType == zone)
            {
                return true;
            }
        }
        return false;
    }
    
   
    
    
}
