using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemLoot : MonoBehaviour
{
    float range;
    //What to drag to the player using "Physics2D.Overlap".
    //int layerMask = 1 << LayerMask.NameToLayer("Gold");
    bool onMagnet;
    int coin = 0;
    public int getCoin
    {
        get { return coin; }
        set { coin += value; }
    }
    public int lostCoin
    {
        get { return coin; }
        set { coin -= value; }
    }
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
        getCoin = 100;
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
        Debug.Log(_battleItem.Data.name);
        AttackComponent.newBattleItem(_battleItem);
        BattleItems.Add(_battleItem);
    }
    public void ItemUse(BuffItem _buffItem)
    {
        Debug.Log(_buffItem.Data.name);
        Stats.ItemBuff(_buffItem);
        BuffItems.Add(_buffItem);
    }
    public void ItemUse(UseItem _useItem)
    {
        Debug.Log(_useItem.Data.name);
        if (_useItem.Data.recoveryHpValue > 0) Stats.PlayerHeal((int)_useItem.Data.recoveryHpValue);
    }
    public void onShop(bool _setbool)
    {
        AttackComponent.onAttack = _setbool;
    }
}
