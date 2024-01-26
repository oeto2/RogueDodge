using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemLoot : MonoBehaviour
{
    float range;
    //What to drag to the player using "Physics2D.Overlap".
    //int layerMask = 1 << LayerMask.NameToLayer("Gold");
    bool onMagnet;

    //Component
    Rigidbody2D PlayerRigid;
    PlayerStats Stats;
    PlayerAttack AttackComponent;
    List<BattleItem> BattleItems = new List<BattleItem>();
    List<BuffItem> BuffItems = new List<BuffItem>();

    private void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        Stats = GetComponent<PlayerStats>();
        AttackComponent = GetComponent<PlayerAttack>();
        if (!PlayerRigid) Debug.Log("PlayerItemLoot.cs : PlayerRigid is Null!");
        if (!Stats) Debug.Log("PlayerAttack.cs : Stats is Null!");
        if (!AttackComponent) Debug.Log("PlayerAttack.cs : Attack is Null!");
    }

    private void Update()
    {
        if (onMagnet)
        {
            GoldMagnet();
        }
    }
    //A function that drags money to the player like a magnet
    public void GoldMagnet()
    {

    }

    //In the event of a direct conflict with an item
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("BattleItem") || _collision.CompareTag("BuffItem") || _collision.CompareTag("UseItem"))
        {
            GameObject itemData = _collision.gameObject;

            switch (itemData.tag)
            {
                case "BattleItem":
                    ItemUse(_collision.GetComponent<BattleItem>());
                    break;
                case "BuffItem":
                    ItemUse(_collision.GetComponent<BuffItem>());
                    break;
                case "UseItem":
                    ItemUse(_collision.GetComponent<UseItem>());
                    break;
                default:
                    Debug.Log("PlayerItemLoot.cs : Unknown Itemtype");
                    break;
            }
        }
    }

    //Overloading using items
    public void ItemUse(BattleItem _battleItem)
    {
        Debug.Log(_battleItem.name);
        AttackComponent.newBattleItem(_battleItem);
        BattleItems.Add(_battleItem);
    }
    public void ItemUse(BuffItem _buffItem)
    {
        Debug.Log(_buffItem.name);
        Stats.ItemBuff(_buffItem);
        BuffItems.Add(_buffItem);
    }
    public void ItemUse(UseItem _useItem)
    {
        Debug.Log(_useItem.name);
        if (_useItem.Data.recoveryHpValue > 0) Stats.PlayerHeal((int)_useItem.Data.recoveryHpValue);
    }
}
