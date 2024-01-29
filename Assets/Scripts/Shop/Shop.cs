using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    PlayerItemLoot playerInventory;
    [SerializeField] Canvas ShopUI;
    Transform ShopItemTransform;

    [SerializeField] GameObject ShopItemUI;
    private void Start()
    {
        ShopItemTransform = transform.Find("BackGround/Scroll View/Viewport/Content");
        //ItemManager.Instance.BattleItmes
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
