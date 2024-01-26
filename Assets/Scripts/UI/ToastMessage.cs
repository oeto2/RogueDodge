using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    public ToastMessage Instance;
    public Text InfoText;
    public Image ShowItemImage;
    public GameObject GetItemObjcet;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        ItemManager.Instance.GetItemEvent += ShowToastMessage;
    }


    public void ShowToastMessage(GameObject _gameObject)
    {
        GetItemObjcet = _gameObject;

        if (_gameObject != null)
            SetToastMessage();
    }

    public void SetToastMessage()
    {
        switch (GetItemObjcet.tag)
        {
            case "BattleItem":
                BattleItemData battleItemData = GetItemObjcet.GetComponent<BattleItem>().Data;

                InfoText.text = battleItemData.info;
                ShowItemImage.sprite = ItemManager.Instance.BattleItemSprites[battleItemData.index];
                break;

            case "UseItem":
                UseItemData useItemData = GetItemObjcet.GetComponent<UseItem>().Data;

                InfoText.text = useItemData.info;
                ShowItemImage.sprite = ItemManager.Instance.UseItemSprites[useItemData.index];
                break;

            case "BuffItem":
                BuffItemData buffItemData = GetItemObjcet.GetComponent<BuffItem>().Data;

                InfoText.text = buffItemData.info;
                ShowItemImage.sprite = ItemManager.Instance.BuffItemSprites[buffItemData.index];
                break;
        }
    }
}
