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
                        
                        instantiate_Item.GetComponent<CurItemData>().ChangeItem(randomIndexNum);
                        //BattleItem battleItem = new BattleItem(BattleItmes[randomIndexNum]);
                        //instantiate_Item.GetComponent<BattleItem>().Data = battleItem;

                        instantiate_Item.AddComponent<BattleItem>();
                        instantiate_Item.GetComponent<BattleItem>().index = randomIndexNum;
                        instantiate_Item.GetComponent<BattleItem>().name = BattleItmes[randomIndexNum].name;
                        instantiate_Item.GetComponent<BattleItem>().info = BattleItmes[randomIndexNum].info;
                        instantiate_Item.GetComponent<BattleItem>().atkValue = BattleItmes[randomIndexNum].atkValue;
                        instantiate_Item.GetComponent<BattleItem>().atkCoolTimeValue = BattleItmes[randomIndexNum].atkCoolTimeValue;
                        instantiate_Item.GetComponent<BattleItem>().isGet = BattleItmes[randomIndexNum].isGet;
                        instantiate_Item.GetComponent<BattleItem>().eScarcity = BattleItmes[randomIndexNum].eScarcity;
                        instantiate_Item.GetComponent<BattleItem>().eWeaponType = BattleItmes[randomIndexNum].eWeaponType;
                        break;

                    case ITEMTYPE.BUFF:
                        instantiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.BUFF;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BuffItems.Count);

                        instantiate_Item.GetComponent<CurItemData>().ChangeItem(randomIndexNum);

                        instantiate_Item.AddComponent<BuffItem>();
                        instantiate_Item.GetComponent<BuffItem>().index = randomIndexNum;
                        instantiate_Item.GetComponent<BuffItem>().name = BuffItems[randomIndexNum].name;
                        instantiate_Item.GetComponent<BuffItem>().info = BuffItems[randomIndexNum].info;
                        instantiate_Item.GetComponent<BuffItem>().atkValue = BuffItems[randomIndexNum].atkValue;
                        instantiate_Item.GetComponent<BuffItem>().atkCoolTimeValue = BuffItems[randomIndexNum].atkCoolTime;
                        instantiate_Item.GetComponent<BuffItem>().speedValue = BuffItems[randomIndexNum].speedValue;
                        instantiate_Item.GetComponent<BuffItem>().hpValue = BuffItems[randomIndexNum].hpValue;
                        instantiate_Item.GetComponent<BuffItem>().isGet = BuffItems[randomIndexNum].isGet;
                        instantiate_Item.GetComponent<BuffItem>().eScarcity = BuffItems[randomIndexNum].eScarcity;
                        instantiate_Item.GetComponent<BuffItem>().eValueType = BuffItems[randomIndexNum].eValueType;
                        break;

                    case ITEMTYPE.Use:
                        instantiate_Item.GetComponent<CurItemData>().eItemType = ITEMTYPE.Use;
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.UseItems.Count);

                        instantiate_Item.GetComponent<CurItemData>().ChangeItem(randomIndexNum);

                        instantiate_Item.AddComponent<UseItem>();
                        instantiate_Item.GetComponent<UseItem>().index = randomIndexNum;
                        instantiate_Item.GetComponent<UseItem>().name = UseItems[randomIndexNum].name;
                        instantiate_Item.GetComponent<UseItem>().info = UseItems[randomIndexNum].info;
                        instantiate_Item.GetComponent<UseItem>().recoveryHpValue = UseItems[randomIndexNum].recoveryHpValue;
                        instantiate_Item.GetComponent<UseItem>().isGet = UseItems[randomIndexNum].isGet;
                        instantiate_Item.GetComponent<UseItem>().eUseType = UseItems[randomIndexNum].eUseType;
                        instantiate_Item.GetComponent<UseItem>().eScarcity = UseItems[randomIndexNum].eScarcity;
                        break;
                }

                instantiate_Item.transform.parent = ItemSpawnTransform[i];
            }
        }
    }
}
