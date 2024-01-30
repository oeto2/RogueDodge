using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : InteractableObject
{
    [SerializeField] GameObject ShopUIPrefeb;
    GameObject ShopUI;
    Shop ShopComponent;
    void Start()
    {
        if (GameObject.Find("ShopUI") == null) ShopUI = Instantiate(ShopUIPrefeb);
        else ShopUI = GameObject.Find("ShopUI");
        ShopComponent = ShopUI.GetComponent<Shop>();

        InteractionEvent += OnShopUI;
    }

    public void OnShopUI()
    {
        if (ShopUI.activeSelf == false)
            ShopUI.SetActive(true);
        else
            ShopUI.SetActive(false);
    }
}
