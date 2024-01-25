using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurItemData : MonoBehaviour
{
    public int ItemIndexNum;
    public SpriteRenderer ItemSPirteRenderer;
    public Sprite[] BattleItemSprites;
    public Sprite[] BuffItemSprites;
    public Sprite[] UseItemSprites;

    //This itemtype
    public ITEMTYPE eItemType;

    public void Start()
    {
        ChangeItemSprite(ItemIndexNum);
    }
    
    public void ChangeItemSprite(int _index)
    {
        switch(eItemType)
        {
            case ITEMTYPE.BATTLE:
                ItemSPirteRenderer.sprite = BattleItemSprites[_index];
                ItemIndexNum = _index;
                break;

            case ITEMTYPE.BUFF:
                ItemSPirteRenderer.sprite = BuffItemSprites[_index];
                ItemIndexNum = _index;
                break;

            case ITEMTYPE.Use:
                ItemSPirteRenderer.sprite = UseItemSprites[_index];
                ItemIndexNum = _index;
                break;
        }
    }
 }
