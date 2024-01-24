using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Item type to be used in the game
public enum ITEMTYPE
{
    BATTLE,
    BUFF,
    USE
}

//Weapon type to be used in the game
public enum WEAPONTYPE
{
    SWORD,
    BOW,
    STAFF
}

public class Item
{
    int key;
    string name;
    string info;
    bool isUsed;
    ITEMTYPE eItemType;
    WEAPONTYPE eWeaponType;
}
