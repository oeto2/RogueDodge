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

    CameraMovement CameraCS;

    public int maxMonsterNum = 0;
    public int deadMonsterNum = 0;

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
        CameraCS = Camera.main.GetComponent<CameraMovement>();
    }

    public void Start()
    {
        WaveClearEvent += ResetMonsterData;
        WaveClearEvent += WaveClear;
    }

    public void CallWaveClearEvent()
    {
        WaveClearEvent?.Invoke();
        eGameState = GAMESTATE.CLEAR;
    }

    public void CallStageClearEvent()
    {
        Debug.Log("스테이지 클리어 이벤트 호출");
        StageClearEvent?.Invoke();
        eGameState = GAMESTATE.CLEAR;
    }

    //Add Dead Monster 
    public void AddDeadMonsterNum()
    {
        deadMonsterNum++;

        //Call Wave Clear Event
        if (maxMonsterNum == deadMonsterNum)
        {
            CallWaveClearEvent();
        }
    }

    //Add CurMonsterNum
    public void AddCurMonsterNum(int _num) => maxMonsterNum += _num;

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
        //curMonsterNum = curMap.GetComponent<>;

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
        maxMonsterNum = 0;
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
            if (stageNum > 3)
                MainBgmManager.Instance.PlayStageBGM(3);
            else 
                MainBgmManager.Instance.PlayStageBGM(stageNum);

            eWaveType = WAVETYPE.NORMAL;
            player.transform.SetParent(curMap.transform);
            player.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            MainBgmManager.Instance.PlayShopBgm();
            eWaveType = WAVETYPE.SHOP;
            player.transform.SetParent(shop.transform);
            player.transform.position = new Vector3(0, 28, 0);
            CameraCS.LimitCameraArea();
        }
    }
}
