using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuffItem : MonoBehaviour
{
    public int index;
    public string name;
    public string info;
    public float atkValue;
    public float atkCoolTimeValue;
    public float speedValue;
    public float hpValue;
    public bool isGet;
    public SCARCITY eScarcity;
    public VALUETYPE eValueType;

    public BuffItem(int _index, string _name, string _info, float _atkValue,
        float _atkCoolTimeValue, float _speedValue, float _hpValue, bool _isGet, SCARCITY _eScarcity, VALUETYPE _eValueType)
    {
        index = _index;
        name = _name;
        info = _info;
        atkValue = _atkValue;
        atkCoolTimeValue = _atkCoolTimeValue;
        speedValue = _speedValue;
        hpValue = _hpValue;
        isGet = _isGet;
        eScarcity = _eScarcity;
        eValueType = _eValueType;
    }
}
