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

    public List<Vector3> ItemSpawnPosition;

    //Evnet called when player Get item
    public event Action<GameObject> GetItemEvent;

    //Evnet called when player Get item After
    public event Action GetItemAfterEvent;

    public GameObject ItemObject;

    public GameObject[] BattleProjectile;

    public List<GameObject> SpawnItemes;

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
        //Subscription Event
        GameManager.Instance.WaveClearEvent += InstantiateItem;
    }

    //Call Events
    public void CallGetItemEvent(GameObject _gameObject)
    {
        GetItemEvent?.Invoke(_gameObject);
        GameManager.Instance.StartNextWave();
    }
    public void CallGetItemAfterEvent() => GetItemAfterEvent?.Invoke();


    //Instantiate GameItem
    public void InstantiateItem()
    {
        //Setting ItemSpawn Position
        SetItemSpawnPosition();

        if (ItemSpawnPosition != null)
        {
            GameObject instantiate_Item;
            List<int> randomBattleItemIndexNumList = new List<int>();
            List<int> randomBuffItemIndexNumList = new List<int>();
            List<int> randomUesItemIndexNumList = new List<int>();

            for (int i = 0; i < ItemSpawnPosition.Count; i++)
            {
                int randomIndexNum = 0;

                //Random Game Item Type
                int randomItemType = UnityEngine.Random.Range(0, 3);

                instantiate_Item = Instantiate(ItemObject, ItemSpawnPosition[i], Quaternion.identity);
                SpawnItemes.Add(instantiate_Item);

                switch ((ITEMTYPE)randomItemType)
                {
                    case ITEMTYPE.BATTLE:
                        //Set ItemTag
                        instantiate_Item.tag = "BattleItem";

                        //Random Game ItemIdex Number
                        //randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BattleItmes.Count);
                        randomIndexNum = CheckDuplicateRnadomNumber(randomBattleItemIndexNumList, ItemManager.Instance.BattleItmes.Count);
                        randomBattleItemIndexNumList.Add(randomIndexNum);


                        //Add BattleItem Script to ItemObject
                        BattleItem battleItemScript = instantiate_Item.AddComponent<BattleItem>();
                        battleItemScript.Data = new BattleItemData(BattleItmes[randomIndexNum]);

                        //Change Item Image
                        ChangeItemSpriteIamge(instantiate_Item.GetComponentInChildren<SpriteRenderer>(), battleItemScript.Data);

                        break;

                    case ITEMTYPE.BUFF:
                        //Set ItemTag
                        instantiate_Item.tag = "BuffItem";

                        //Random Game ItemIdex Number
                        //randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.BuffItems.Count);
                        randomIndexNum = CheckDuplicateRnadomNumber(randomBuffItemIndexNumList, ItemManager.Instance.BuffItems.Count);
                        randomBuffItemIndexNumList.Add(randomIndexNum);

                        //Add UseItem Script to Item
                        BuffItem buffItemScript = instantiate_Item.AddComponent<BuffItem>();
                        buffItemScript.Data = new BuffItemData(BuffItems[randomIndexNum]);

                        //Chage Item Image
                        ChangeItemSpriteIamge(instantiate_Item.GetComponentInChildren<SpriteRenderer>(), buffItemScript.Data);
                        break;

                    case ITEMTYPE.Use:
                        //Set ItemTag
                        instantiate_Item.tag = "UseItem";

                        //Random Game ItemIdex Number
                        //randomIndexNum = UnityEngine.Random.Range(0, ItemManager.Instance.UseItems.Count);
                        randomIndexNum = CheckDuplicateRnadomNumber(randomUesItemIndexNumList, ItemManager.Instance.UseItems.Count);
                        randomUesItemIndexNumList.Add(randomIndexNum);

                        //Add UseItem Script to Item
                        UseItem useItemScript = instantiate_Item.AddComponent<UseItem>();
                        useItemScript.Data = new UseItemData(UseItems[randomIndexNum]);

                        //Change Item Image
                        ChangeItemSpriteIamge(instantiate_Item.GetComponentInChildren<SpriteRenderer>(), useItemScript.Data);
                        break;
                }

                //Set transform parent of this Item
                instantiate_Item.transform.parent = GameManager.Instance.curMap.transform;
            }
        }
    }

    public void SetItemSpawnPosition()
    {
        //Reset ItemSpawn Postion
        ItemSpawnPosition.Clear();

        //Find ItemSpawn Position 
        Map mapScript = GameManager.Instance.curMap.GetComponent<Map>();
        Transform curMapTranstorm = GameManager.Instance.curMap.transform;

        if (mapScript != null)
        {
            foreach (Vector3 vec3 in mapScript.itemSpawn)
            {
                ItemSpawnPosition.Add(new Vector3(vec3.x + curMapTranstorm.position.x, vec3.y + curMapTranstorm.position.y,
                    vec3.z));
            }
        }
    }

    //Destroy Spawn Items
    public IEnumerator DestroyAllItem()
    {
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < SpawnItemes.Count; i++)
        {
            DestroyObject(SpawnItemes[i]);
        }

        SpawnItemes.Clear();
    }

    //Check the Rndom number of duplicates
    public int CheckDuplicateRnadomNumber(List<int> _duplicateNumberList, int _MaxRandomValue)
    {
        int randomNum = 0;

        while (true)
        {
            randomNum = UnityEngine.Random.Range(0, _MaxRandomValue);
            bool isDuplicate = false;

            if (_duplicateNumberList != null)
            {
                foreach (int number in _duplicateNumberList)
                {
                    if (number == randomNum)
                        isDuplicate = true;
                }

                if (!isDuplicate) break;
            }
            else break;
        }

        return randomNum;
    }

    #region ChageItemFunctions
    public void ChangeItemSpriteIamge(SpriteRenderer _spriteRenderer, BattleItemData _battleItemData)
    { _spriteRenderer.sprite = BattleItemSprites[_battleItemData.index]; }

    public void ChangeItemSpriteIamge(SpriteRenderer _spriteRenderer, UseItemData _useItemData)
    { _spriteRenderer.sprite = UseItemSprites[_useItemData.index]; }

    public void ChangeItemSpriteIamge(SpriteRenderer _spriteRenderer, BuffItemData _buffItemData)
    { _spriteRenderer.sprite = BuffItemSprites[_buffItemData.index]; }
    #endregion
}
