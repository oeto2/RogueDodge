using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleItem : MonoBehaviour
{
    public BattleItem Data;

    public int index;
    public string name;
    public string info;
    public float atkValue;
    public float atkCoolTimeValue;
    public bool isGet;
    public SCARCITY eScarcity;
    public WEAPONTYPE eWeaponType;

    public BattleItem(int _index, string _name, string _info, float _atkValue,
        float _atkCoolTimeValue, bool _isGet, SCARCITY _eScarcity, WEAPONTYPE _eWeaponType)
    {
        index = _index;
        name = _name;
        info = _info;
        atkValue = _atkValue;
        atkCoolTimeValue = _atkCoolTimeValue;
        isGet = _isGet;
        eScarcity = _eScarcity;
        eWeaponType = _eWeaponType;
    }

    public BattleItem(BattleItemDataBaseEntity _battleData)
    {
        index = _battleData.index;
        name = _battleData.name;
        info = _battleData.info;
        atkValue = _battleData.atkValue;
        atkCoolTimeValue = _battleData.atkCoolTimeValue;
        isGet = _battleData.isGet;
        eScarcity = _battleData.eScarcity;
        eWeaponType = _battleData.eWeaponType;
    }

    public BattleItem() { }
}
