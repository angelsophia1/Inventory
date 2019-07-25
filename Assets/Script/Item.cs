using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type,description;
    public Sprite icon;
    public bool pickedUp,playersWeapon;
    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject weapon,weaponManager;

    public void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        //This is a common script, not only for weapons on the ground, but also for weapons used by player
        if (!playersWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;
            for (int i =0;i< allWeapons;i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    public void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                weapon.GetComponent<Item>().equipped = false;
                weapon.SetActive(false);
            }
        }
    }
    public void ItemUsage()
    {
        if (type=="Weapon")
        {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
        }
    }
}
