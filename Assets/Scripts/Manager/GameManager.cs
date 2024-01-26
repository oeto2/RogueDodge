using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance = null;

    private int gold { get; set; }
    public Transform PlayerTransform;

    public GameObject curMap;
    public GameObject player;

    [SerializeField]
    private int curMonsterNum = 0;
    [SerializeField]
    private int deadMonsterNum = 0;

    //Call event When Clear Wave 
    public event Action WaveClearEvent;

    //Call event When Clear Stage 
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
    }

    public void CallWaveClearEvent()
    {
        WaveClearEvent?.Invoke();
    }

    public void CallStageClearEvent()
    {
        StageClearEvent?.Invoke();
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
    public void AddCurMonsterNum(int _num)
    {
        curMonsterNum += _num;
    }

    //Call Function when Clear current stage 
    public void StageClear()
    {
        //TO DO
    }

    public void ResetMonsterData()
    {
        curMonsterNum = 0;
        deadMonsterNum = 0;
    }
}
