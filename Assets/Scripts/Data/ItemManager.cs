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
    private event Action GetItemEvent;

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
            GameObject instactiate_Item;

            for (int i = 0; i < ItemSpawnTransform.Length; i++)
            {
                int randomIndexNum = 0;
                //Random Game Item Type
                int randomItemType = UnityEngine.Random.Range(0, 3);
                instactiate_Item = Instantiate(ItemObject, ItemSpawnTransform[i].position, Quaternion.identity);

                switch ((ITEMTYPE)randomItemType)
                {
                    case ITEMTYPE.BATTLE:
                        instactiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.BATTLE;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BattleItmes.Count);
                        
                        instactiate_Item.GetComponent<CurItemData>().ChangeItemSprite(randomIndexNum); 
                        break;

                    case ITEMTYPE.BUFF:
                        instactiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.BUFF;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BuffItems.Count);

                        instactiate_Item.GetComponent<CurItemData>().ChangeItemSprite(randomIndexNum);
                        break;

                    case ITEMTYPE.Use:
                        instactiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.Use;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.UseItems.Count);

                        instactiate_Item.GetComponent<CurItemData>().ChangeItemSprite(randomIndexNum);
                        break;
                }

                instactiate_Item.transform.parent = ItemSpawnTransform[i];
            }
        }
    }
}
