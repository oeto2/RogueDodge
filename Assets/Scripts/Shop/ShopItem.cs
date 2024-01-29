using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItem : MonoBehaviour
{
    Image ItemUIImage;
    Text ItemText;
    public UseItemData useItemData { get; private set; }
    public int itemIndex;
    public int price { get; private set; }
    public void SetItemInfo(int _index, UseItemData _useItemData, Sprite _sprite, string _name, string _info, int _price)
    {
        if(!ItemUIImage) { ItemUIImage = transform.Find("Image").GetComponent<Image>(); }
        if(!ItemText) { ItemText = transform.Find("Text").GetComponent<Text>(); ItemText.text = ""; }

        itemIndex = _index;
        useItemData = _useItemData;
        ItemUIImage.sprite = _sprite;
        ItemText.text += _name;
        ItemText.text += $"\n{_info}";
        ItemText.text += $"\n°¡°Ý : {_price}";
        price = _price;
    }

    private void Start()
    {
        ItemUIImage = transform.Find("Image").GetComponent<Image>();
        ItemText = transform.Find("Text").GetComponent<Text>();
    }
}
