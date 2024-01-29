using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    public ToastMessage Instance;
    public Text ToastMessageItemName;
    public Text ToastMessageInfo;
    public Image ToastMessageItemImage;
    public GameObject ToastMessageObject;

    public Color32 NormalColor;
    public Color32 RareColor;
    public Color32 UniqueColor;

    [SerializeField]
    [Range(0, 10f)] private float CloseMessageTime = 3f;

    public Animator ToastMessageAnimator;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        ItemManager.Instance.GetItemEvent += ShowToastMessage;
    }


    public void ShowToastMessage(GameObject _gameObject)
    {
        if (_gameObject != null)
            SetToastMessage(_gameObject);
    }

    //Setting ToastMessage
    public void SetToastMessage(GameObject _gameObject)
    {
        ResetStartToastMessageAnimation();

        //Start ToastMessage Animation
        StartCoroutine(StartToastMessageAnimation());

        switch (_gameObject.tag)
        {
            case "BattleItem":
                BattleItemData battleItemData = _gameObject.GetComponent<BattleItem>().Data;

                //Setting ToastMessage 
                ToastMessageInfo.text = battleItemData.info;
                ToastMessageItemName.text = battleItemData.name;
                ChangeTextColor(ToastMessageItemName, battleItemData.eScarcity);
                ToastMessageItemImage.sprite = ItemManager.Instance.BattleItemSprites[battleItemData.index];
                break;

            case "UseItem":
                UseItemData useItemData = _gameObject.GetComponent<UseItem>().Data;

                //Setting ToastMessage 
                ToastMessageInfo.text = useItemData.info;
                ToastMessageItemName.text = useItemData.name;
                ChangeTextColor(ToastMessageItemName, useItemData.eScarcity);
                ToastMessageItemImage.sprite = ItemManager.Instance.UseItemSprites[useItemData.index];
                break;

            case "BuffItem":
                BuffItemData buffItemData = _gameObject.GetComponent<BuffItem>().Data;

                //Setting ToastMessage 
                ToastMessageInfo.text = buffItemData.info;
                ToastMessageItemName.text = buffItemData.name;
                ChangeTextColor(ToastMessageItemName, buffItemData.eScarcity);
                ToastMessageItemImage.sprite = ItemManager.Instance.BuffItemSprites[buffItemData.index];
                break;
        }
    }

    //Change Text color according to scarcity
    public void ChangeTextColor(Text _text, SCARCITY _scarcity)
    {
        switch(_scarcity)
        {
            case SCARCITY.NORMAL:
                _text.color = NormalColor;
                break;

            case SCARCITY.RARE:
                _text.color = RareColor;
                break;

            case SCARCITY.UNIQUE:
                _text.color = UniqueColor;
                break;
        }
    }

    IEnumerator StartToastMessageAnimation()
    {
        ToastMessageObject.SetActive(true);

        yield return new WaitForSeconds(CloseMessageTime);
        ToastMessageAnimator.SetTrigger("CloseMessage");
        yield return new WaitForSeconds(1f);

        ToastMessageObject.SetActive(false);
    }

    public void ResetStartToastMessageAnimation()
    {
        ToastMessageObject.SetActive(false);
        StopAllCoroutines();
    }
}
