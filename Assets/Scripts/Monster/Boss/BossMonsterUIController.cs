using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMonsterUIController : MonoBehaviour
{
    public GameObject ui;
    public Slider hpBarSlider;
    
    MonsterStats monsterStats;
    MonsterController monsterController;

    public GameObject parentObj;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        monsterController.OnHitEvent += Hit;
        monsterController.OnDeathEvent += DestroyObj;
        ui.GetComponent<Canvas>().worldCamera = Camera.main;
       
    }
    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        HpSliderInit();
    }


    void Hit()
    {
        hpBarSlider.value = monsterStats.hp;
    }

    void HpSliderInit()
    {
        hpBarSlider.maxValue = monsterStats.hp;
        hpBarSlider.value = monsterStats.hp;
    }

    public void SetActiveUi()
    {
        if (ui.activeSelf)
        {
            ui.SetActive(false);
        }
        else
        {
            ui.SetActive(true);
        }
    }

    public void DestroyObj()
    {
        Destroy(parentObj,5f);
    }

}
