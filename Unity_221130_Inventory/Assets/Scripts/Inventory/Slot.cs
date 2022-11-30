using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image itemImage;
    
    public GameObject itemInfo;
    public Text itemName;
    public Text itemEffect;
    public Text itemPrice;

    private Sprite sprite;

    private void Awake()
    {
        itemInfo = transform.Find("ItemInfoText").gameObject;
        itemName = itemInfo.transform.Find("Name").gameObject.GetComponent<Text>();
        itemEffect = itemInfo.transform.Find("Effect").gameObject.GetComponent<Text>();
        itemPrice = itemInfo.transform.Find("Price").gameObject.GetComponent<Text>();

        itemImage = transform.Find("ItemImage").gameObject.GetComponent<Image>();

        itemInfo.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void SetColor(float alpha)
    {
        Color color = itemImage.color;
        color.a = alpha;
        itemImage.color = color;
    }

    public void AddItem(DataManager.ItemData data)
    {
        sprite = Resources.Load<Sprite>("Image/Item/" + data.name);
        itemImage.sprite = sprite;
        itemName.text = data.name;
        itemEffect.text = data.effect;
        itemPrice.text = data.price;

        SetColor(1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!itemInfo.activeSelf)
        {
            itemInfo.SetActive(true);
        }

        print("item info = true");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemInfo.activeSelf)
        {
            itemInfo.SetActive(false);

        }

        print("item info = false");
    }
}
