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

    public Sprite[] BattleItemSprites;
    public Sprite[] BuffItemSprites;
    public Sprite[] UseItemSprites;

    public Transform[] ItemSpawnTransform;

    //Evnet called when an Get item
    public event Action<GameObject> GetItemEvent;

    public GameObject ItemObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
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
    public void CallGetItemEvnet(GameObject _gameObject) => GetItemEvent?.Invoke(_gameObject);

    //Instantiate GameItem
    public void InstantiateItem()
    {
        if (ItemSpawnTransform != null)
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
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BattleItmes.Count);

                        //Add BattleItem Script to ItemObject
                        BattleItem battleItemScript = instantiate_Item.AddComponent<BattleItem>();
                        battleItemScript.Data = new BattleItemData(BattleItmes[randomIndexNum]);

                        //Chage Item Image
                        ChangeItemSpriteIamge(instantiate_Item.GetComponentInChildren<SpriteRenderer>(), battleItemScript.Data);

                        break;

                    case ITEMTYPE.BUFF:
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BuffItems.Count);

                        //Add UseItem Script to Item
                        BuffItem buffItemScript = instantiate_Item.AddComponent<BuffItem>();
                        buffItemScript.Data = new BuffItemData(BuffItems[randomIndexNum]);

                        //Chage Item Image
                        ChangeItemSpriteIamge(instantiate_Item.GetComponentInChildren<SpriteRenderer>(), buffItemScript.Data);
                        break;

                    case ITEMTYPE.Use:
                        //Random Game ItemIdex Number
                        randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.UseItems.Count);

                        //Add UseItem Script to Item
                        UseItem useItemScript = instantiate_Item.AddComponent<UseItem>();
                        useItemScript.Data = new UseItemData(UseItems[randomIndexNum]);

                        //Chage Item Image
                        ChangeItemSpriteIamge(instantiate_Item.GetComponentInChildren<SpriteRenderer>(), useItemScript.Data);
                        break;
                }

                //Set transform parent of this Item
                instantiate_Item.transform.parent = ItemSpawnTransform[i];
            }
        }
    }

    #region ChageItemFunctions
    public void ChangeItemSpriteIamge(SpriteRenderer _spriteRenderer, BattleItemData _battleItemData)
    { _spriteRenderer.sprite = BattleItemSprites[_battleItemData.index];}

    public void ChangeItemSpriteIamge(SpriteRenderer _spriteRenderer, UseItemData _useItemData)
    { _spriteRenderer.sprite = UseItemSprites[_useItemData.index]; }

    public void ChangeItemSpriteIamge(SpriteRenderer _spriteRenderer, BuffItemData _buffItemData)
    { _spriteRenderer.sprite = BuffItemSprites[_buffItemData.index]; }
    #endregion
}
