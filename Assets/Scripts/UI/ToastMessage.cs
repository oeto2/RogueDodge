using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastMessage : MonoBehaviour
{
    public ToastMessage Instance;
    public Text InfoText;
    public GameObject GetItemObjcet;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        ItemManager.Instance.GetItemEvent += SetGetItemObjcet;
    }


    public void SetGetItemObjcet(GameObject _gameObject) => GetItemObjcet = _gameObject;
}
