using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour,IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type,description;
    public bool empty;
    public Sprite icon;
    public Transform slotIconGO;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }

    public void UpdateSlot()
    {
        slotIconGO = transform.GetChild(0);
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.GetComponent<Item>().ItemUsage();
        }
    }
}
