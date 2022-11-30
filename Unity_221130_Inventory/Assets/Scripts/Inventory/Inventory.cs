using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameObject inventoryBase;
    private Transform slotsParent;

    private List<Slot> slots = new List<Slot>();

    private bool inventoryActive = false;

    private void Awake()
    {
        Transform[] children = GetComponentsInChildren<Transform>();

        foreach(Transform child in children)
        {
            if (child.name == "Content")
                slotsParent = child;
            else if (child.name == "Scroll View")
                inventoryBase = child.gameObject;
        }
    }

    private void Start()
    {
        AddItems();
        //transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
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
        GameObject slotPrefab = Resources.Load<GameObject>("Prefabs/Slot");
        List<DataManager.ItemData> itemDatas = DataManager.instance.itemData;
        
        foreach(DataManager.ItemData itemData in itemDatas)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotsParent);
            Slot slot = slotObj.GetComponent<Slot>();
            slot.AddItem(itemData);
            slots.Add(slot);
        }
    }
}
