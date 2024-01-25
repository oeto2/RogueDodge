using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance = null;

    public ItemDatabase ItemDatas;
    public List<BattleItemDataBaseEntity> BattleItmes;
    public List<BuffItemDataBaseEntity> BuffItems;
    public List<UseItemDataBaseEntity> UseItems;

    public Transform[] ItemSpawnTransform;

    //Evnet called when an Get item
    public event Action GetItemEvent;

    public GameObject ItemObject;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        BattleItmes = ItemDatas.BattleItem;
        BuffItems = ItemDatas.BuffItem;
        UseItems = ItemDatas.UseItem;
    }

    private void Start()
    {
        InstantiateItem();
    }

    //Call Event
    public void CallGetItemEvnet() => GetItemEvent?.Invoke();

    //Instantiate GameItem
    public void InstantiateItem()
    {
        if(ItemSpawnTransform != null)
        {
            GameObject instantiate_Item;

            for (int i = 0; i < ItemSpawnTransform.Length; i++)
            {
                int randomIndexNum = 0;
                //Random Game Item Type
                int randomItemType = UnityEngine.Random.Range(0, 3);
                instantiate_Item = Instantiate(ItemObject, ItemSpawnTransform[i].position, Quaternion.identity);

                switch ((ITEMTYPE)randomItemType)
                {
                    case ITEMTYPE.BATTLE:
                        instantiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.BATTLE;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BattleItmes.Count);
                        
                        //Chage Item Image
                        instantiate_Item.GetComponent<CurItemData>().ChangeItem(randomIndexNum);

                        
                        instantiate_Item.AddComponent<BattleItem>();
                        instantiate_Item.GetComponent<BattleItem>().Data = new BattleItemData(BattleItmes[randomIndexNum]);
                        break;

                    case ITEMTYPE.BUFF:
                        instantiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.BUFF;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BuffItems.Count);
                        
                        //Chage Item Image
                        instantiate_Item.GetComponent<CurItemData>().ChangeItem(randomIndexNum);

                        //Add UseItem Script to Item
                        instantiate_Item.AddComponent<BuffItem>();
                        instantiate_Item.GetComponent<BuffItem>().Data = new BuffItemData(BuffItems[randomIndexNum]);
                        break;

                    case ITEMTYPE.Use:
                        instantiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.Use;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.UseItems.Count);

                        //Chage Item Image
                        instantiate_Item.GetComponent<CurItemData>().ChangeItem(randomIndexNum);

                        //Add UseItem Script to Item
                        instantiate_Item.AddComponent<UseItem>();
                        instantiate_Item.GetComponent<UseItem>().Data = new UseItemData(UseItems[randomIndexNum]);
                        break;
                }

                //Set transform parent of this Item
                instantiate_Item.transform.parent = ItemSpawnTransform[i];
            }
        }
    }
}
