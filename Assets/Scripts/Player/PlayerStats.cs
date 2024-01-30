using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    string name = "";

    PlayerAttack AttackComponent;
    PlayerMovement MoveComponent;

    //Curren Equip WeaponType
    public WEAPONTYPE eEquipWeaponType = WEAPONTYPE.SWORD;

    //HP
    [SerializeField] int defaultMaxHp = 100;
    [SerializeField] int buffedMaxHp = 0;
    [SerializeField] int currentMaxHp { get { return defaultMaxHp + buffedMaxHp; } }
    public int getMaxHp { get { return currentMaxHp; } }
    [SerializeField] int hp = 0;
    
    //Speed
    [SerializeField] float defaultSpeed = 10f;
    [SerializeField] float buffedSpeed = 0f;
    [SerializeField] float currentSpeed { get { return defaultSpeed + buffedSpeed; } }
    public float getSpeed{ get { return currentSpeed; } }
    
    //Atk
    [SerializeField] float defaultAtk = 10f;
    [SerializeField] float buffedAtk = 0f;
    [SerializeField] float currentAtk
    {
        get { return defaultAtk + buffedAtk; }
    }
    public float getAtk { get { return currentAtk; } }

    //AtkCoolTime
    float minAtkCoolTime = 0.1f;
    float maxAtkCoolTime = 10.0f;
    [SerializeField] float defaultAtkCoolTime = 1f;
    [SerializeField] float buffedAtkCoolTime = 0;
    [SerializeField]
    float currentAtkCoolTime
    {
        get { return Mathf.Clamp(defaultAtkCoolTime - buffedAtkCoolTime, minAtkCoolTime, maxAtkCoolTime); }
    }
    public float getAtkCoolTime { get { return currentAtkCoolTime; } }

    //bool
    public bool isDead { get { return hp <= 0; } }

    [SerializeField] Animator anim;
    private void Start()
    {
        hp = currentMaxHp;
        AttackComponent = GetComponent<PlayerAttack>();
        MoveComponent = GetComponent<PlayerMovement>();
        if (!AttackComponent) Debug.Log("PlayerStats.cs : AttackComponent is Null!");
        if (!MoveComponent) Debug.Log("PlayerStats.cs : MoveComponent is Null!");
        ItemManager.Instance.GetItemEvent += ChageWeaponType;
    }

    public void PlayerDamaged(int _damage)
    {
        //Play Hit Sound of Player
        MainEffectManager.Instance.PlayPlayerHitSound();

        UIManager.Instance.playerHpUIScript.ApplyDamageToPlayerHpUI(getMaxHp, hp, _damage);
        hp -= _damage;
        if (isDead) PlayerDead();
    }
    public void PlayerDead()
    {
        //Play Dead Sound of Player
        MainEffectManager.Instance.PlayPlayerDeadSound();
         
        AttackComponent.onAttack = false;
        MoveComponent.onMove = false;
        Debug.Log("Player is Dead");
        anim.SetTrigger("Dead");
    }
    public void ItemBuff(BuffItem _buffItem)
    {
        buffedAtk += _buffItem.Data.atkValue;
        buffedMaxHp += (int)_buffItem.Data.hpValue;
        hp += (int)_buffItem.Data.hpValue;
        buffedSpeed += _buffItem.Data.speedValue;
        buffedAtkCoolTime += _buffItem.Data.atkCoolTimeValue;
    }
    public void PlayerHeal(int _healPoint)
    {
        UIManager.Instance.playerHpUIScript.ApplyHealToPlayerHpUI(getMaxHp, hp, _healPoint);
        hp = Mathf.Clamp(hp + _healPoint, 0, currentMaxHp);
    }
    public void Player_SetDefaultAtkStat(float _atk, float _atkCoolTime)
    {
        defaultAtk = _atk;
        defaultAtkCoolTime = _atkCoolTime;
    }
    public void ChageWeaponType(GameObject _Item)
    {
        if (_Item.CompareTag("BattleItem"))
        {
            eEquipWeaponType =  _Item.GetComponent<BattleItem>().Data.eWeaponType;
        }
    }
}
