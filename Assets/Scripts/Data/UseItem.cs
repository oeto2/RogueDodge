using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseItem : MonoBehaviour
{
    public int index;
    public string name;
    public string info;
    public float recoveryHpValue;
    public bool isGet;
    public USETYPE eUseType;
    public SCARCITY eScarcity;

    public UseItem(int _index, string _name, string _info, float _recoveryHpValue,
         bool _isGet, USETYPE _eUseType, SCARCITY _eScarcity)
    {
        index = _index;
        name = _name;
        info = _info;
        recoveryHpValue = _recoveryHpValue;
        isGet = _isGet;
        eUseType = _eUseType;
        eScarcity = _eScarcity;
    }

    public UseItem() { }
}
