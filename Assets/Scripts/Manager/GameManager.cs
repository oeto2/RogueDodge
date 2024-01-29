using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum GAMESTATE
{
    BATTLE, //Fighting monsters
    CLEAR //Wave Or Stage Clear Or Shopping
}

public enum WAVETYPE
{
    NORMAL,
    BOSS,
    SHOP
}

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance = null;

    public GAMESTATE eGameState = GAMESTATE.BATTLE;
    public WAVETYPE eWaveType = WAVETYPE.NORMAL;

    private int gold { get; set; }
    public Transform PlayerTransform;

    public GameObject curMap;
    public GameObject player;
    public GameObject shop;

    [SerializeField]
    private int curMonsterNum = 0;
    [SerializeField]
    private int deadMonsterNum = 0;

    public int curWaveNum = 1;
    public int targetWaveNum = 3;
    public int stageNum = 1;

    //Call event When dead all monsters
    public event Action WaveClearEvent;

    //Call event When dead boss monster
    public event Action StageClearEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }

        //TODO: if GameObject player is available -> delete
        PlayerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void Start()
    {
        WaveClearEvent += ResetMonsterData;
        WaveClearEvent += WaveClear;
        StageClearEvent += StageClear;
    }

    public void CallWaveClearEvent()
    {
        WaveClearEvent?.Invoke();
        eGameState = GAMESTATE.CLEAR;
    }

    public void CallStageClearEvent()
    {
        StageClearEvent?.Invoke();
        eGameState = GAMESTATE.CLEAR;
    }

    //Add Dead Monster 
    public void AddDeadMonsterNum()
    {
        deadMonsterNum++;

        //Call Wave Clear Event
        if (curMonsterNum == deadMonsterNum)
        {
            CallWaveClearEvent();
        }
    }

    //Add CurMonsterNum
    public void AddCurMonsterNum(int _num) => curMonsterNum += _num;

    //Call Function when Dead BossMonster
    public void StageClear()
    {
        eGameState = GAMESTATE.CLEAR;
        eWaveType = WAVETYPE.NORMAL;
        stageNum++;

        //Call Stage Clear Event
        CallStageClearEvent();
    }

    public void WaveClear()
    {
        eGameState = GAMESTATE.CLEAR;
        deadMonsterNum = 0;

        //TODO: Get CurrentMonsterNum to Map Obj
        curMonsterNum = 1;

        if (curWaveNum < targetWaveNum)
            curWaveNum++;
        else
        {
            eWaveType = WAVETYPE.BOSS;
            StageStatusUI.Instance.ChangeWaveStatusImageToBoss();
            ResetWave();
        }
    }

    public void ResetMonsterData()
    {
        curMonsterNum = 0;
        deadMonsterNum = 0;
    }

    public void ResetWave()
    {
        curWaveNum = 1;
        targetWaveNum = 3;
    }

    public void StartNextWave() => eGameState = GAMESTATE.BATTLE;

    public void Teleport(bool isMap)
    {
        //TODO: need Teleport Animation 
        if (isMap)
        {
            Debug.Log("MapPortal");
            player.transform.SetParent(curMap.transform);
            player.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            Debug.Log("ShopPortal");
            player.transform.SetParent(shop.transform);
            player.transform.position = new Vector3(0, -2, 0);
        }
    }
}
