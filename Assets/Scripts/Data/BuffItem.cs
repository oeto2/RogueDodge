using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BuffItemData
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

    public BuffItemData(BuffItemDataBaseEntity _buffItemEntity)
    {
        index = _buffItemEntity.index;
        name = _buffItemEntity.name;
        info = _buffItemEntity.info;
        atkValue = _buffItemEntity.atkValue;
        atkCoolTimeValue = _buffItemEntity.atkCoolTime;
        speedValue = _buffItemEntity.speedValue;
        hpValue = _buffItemEntity.hpValue;
        isGet = _buffItemEntity.isGet;
        eScarcity = _buffItemEntity.eScarcity;
        eValueType = _buffItemEntity.eValueType;
    }
}


public class BuffItem : MonoBehaviour
{
    public BuffItemData Data;
}
