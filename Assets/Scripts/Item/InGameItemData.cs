using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameItemData : MonoBehaviour
{
    public SpriteRenderer ItemSPirteRenderer;
    public Sprite[] ItemSprites;
    public ITEMTYPE eItemType;


    public void ChangeItemSprite(Sprite _sprite)
    {
        ItemSPirteRenderer.sprite = _sprite;
    }
}
