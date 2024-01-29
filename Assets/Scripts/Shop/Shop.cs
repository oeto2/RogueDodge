using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    PlayerItemLoot playerInventory;
    Transform ShopItemTransform;

    [SerializeField] GameObject ShopItemUI;
    List<ShopItem> ShopItems = new List<ShopItem>();
    [SerializeField] Text PlayerCoinUI;
    private void Start()
    {
        ShopItemTransform = transform.Find("BackGround/Scroll View/Viewport/Content");
        gameObject.SetActive(false);
        int idx = 0;
        foreach(UseItemDataBaseEntity item in ItemManager.Instance.UseItems)
        {
            if (item.index < ItemManager.Instance.UseItemSprites.Length)
            {
                GameObject obj = Instantiate(ShopItemUI, ShopItemTransform);
                ShopItem obj_Component = obj.AddComponent<ShopItem>();
                Button obj_Button = obj.GetComponent<Button>();

                obj_Component.SetItemInfo(idx, new UseItemData(ItemManager.Instance.UseItems[idx]), ItemManager.Instance.UseItemSprites[item.index], item.name, item.info, 50);
                obj_Button.onClick.AddListener( delegate { BuyItem(idx); } );
                idx++;

                ShopItems.Add(obj_Component);
            }
            else
            {
                Debug.Log("오류 : ItemManager.UseItemSprites 스프라이트 이미지가 부족합니다.");
            }
        }
    }

    private void OnEnable()
    {
        if (!playerInventory)
        {
            if (GameManager.Instance.player.TryGetComponent<PlayerItemLoot>(out playerInventory))
            {
                PlayerCoinUI.text = playerInventory.getCoin.ToString() + " G";
            }
            else
            {
                Debug.Log("Shop.cs : playerInventory is Null!");
            }
        }
    }

    public void BuyItem(int _index)
    {
        ShopItem shopItem = ShopItems.Find(item => item.itemIndex == _index);

        if (playerInventory.getCoin > shopItem.price)
        {
            UseItem shopUseItem = new UseItem();
            shopUseItem.Data = shopItem.useItemData;
            playerInventory.ItemUse(shopUseItem);
            playerInventory.lostCoin = shopItem.price;
        }
        else
        {
            Debug.Log("돈이 부족합니다.");
        }
        
    }
}
