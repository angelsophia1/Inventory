using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory,slotHolder;
    private GameObject[] slot;
    private bool inventoryEnabled ;
    private int allslots;
    private float moveSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        allslots = 36;
        inventoryEnabled = false;
        slot = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            if (inventoryEnabled == true)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }
        if (Mathf.Abs(Input.GetAxis("Horizontal"))>0||Mathf.Abs(Input.GetAxis("Vertical"))>0)
        {
            float xMove = Input.GetAxis("Horizontal") * moveSpeed *Time.deltaTime;
            float yMove = Input.GetAxis("Vertical") * moveSpeed*Time.deltaTime;
            Vector3 deltaMove = new Vector3(xMove,yMove,0f);
            transform.position = transform.position + deltaMove;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp,item.ID, item.type, item.description, item.icon);
        }
    }
    void AddItem(GameObject itemObject,int itemID,string itemType,string itemDescription, Sprite itemIcon)
    {
        for (int i = 0;i<allslots;i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().description = itemDescription;

                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
    }
}
