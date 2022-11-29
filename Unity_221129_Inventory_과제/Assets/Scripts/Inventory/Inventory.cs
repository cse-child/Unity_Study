using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject inventoryBase;
    private GameObject slotsParent;

    private Slot[] slots;

    private bool inventoryActive = false;

    private void Awake()
    {
        inventoryBase =transform.GetChild(0).GetChild(0).gameObject;
        slotsParent = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;

        slots = slotsParent.GetComponentsInChildren<Slot>();
    }

    private void Start()
    {
        AddItems();
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        ShowInventory();
    }

    private void ShowInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(!inventoryActive)
            {
                inventoryActive = true;
                inventoryBase.SetActive(true);
            }
            else
            {
                inventoryActive = false;
                inventoryBase.SetActive(false);
            }
        }
    }

    private void AddItems()
    {
        List<DataManager.ItemData> itemDatas = DataManager.instance.itemData;
        int idx = 0;
        foreach(DataManager.ItemData itemData in itemDatas)
        {
            slots[idx++].AddItem(itemData);
        }
        //string[] itemImage = { "axe", "hp", "bag", "sword", "helmets", "Meat" };

        //int a = itemImage.Length;
        //print(a);
        //for(int i = 0; i < itemImage.Length; i++)
        //{
        //    slots[i].AddItem(itemImage[i]);
        //}
    }
}
