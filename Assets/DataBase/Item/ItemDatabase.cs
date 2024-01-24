using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ItemDatabase : ScriptableObject
{
	public List<BattleItemDataBaseEntity> BattleItem; // Replace 'EntityType' to an actual type that is serializable.
	public List<UseItemDataBaseEntity> UseItem; // Replace 'EntityType' to an actual type that is serializable.
	public List<BuffItemDataBaseEntity> BuffItem; // Replace 'EntityType' to an actual type that is serializable.
}
