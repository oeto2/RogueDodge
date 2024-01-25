using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class UseItemData
{
    public int index;
    public string name;
    public string info;
    public float recoveryHpValue;
    public bool isGet;
    public USETYPE eUseType;
    public SCARCITY eScarcity;

    public UseItemData(UseItemDataBaseEntity _useItemEntity)
    {
        index = _useItemEntity.index;
        name = _useItemEntity.name;
        info = _useItemEntity.info;
        recoveryHpValue = _useItemEntity.recoveryHpValue;
        isGet = _useItemEntity.isGet;
        eUseType = _useItemEntity.eUseType;
        eScarcity = _useItemEntity.eScarcity;
    }
}


public class UseItem : MonoBehaviour
{
    public UseItemData Data;
}
