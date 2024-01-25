using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BattleItemData
{
    public int index;
    public string name;
    public string info;
    public float atkValue;
    public float atkCoolTimeValue;
    public bool isGet;
    public SCARCITY eScarcity;
    public WEAPONTYPE eWeaponType;

    public BattleItemData(BattleItemDataBaseEntity _battleItemEntity)
    {
        index = _battleItemEntity.index;
        name = _battleItemEntity.name;
        info = _battleItemEntity.info;
        atkValue = _battleItemEntity.atkValue;
        atkCoolTimeValue = _battleItemEntity.atkCoolTimeValue;
        isGet = _battleItemEntity.isGet;
        eScarcity = _battleItemEntity.eScarcity;
        eWeaponType = _battleItemEntity.eWeaponType;
    }
}

[System.Serializable]
public class BattleItem : MonoBehaviour
{
    public BattleItemData Data;
}
