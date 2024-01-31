using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStatusUI : MonoBehaviour
{
    public static StageStatusUI Instance;

    [SerializeField] Text WaveText;

    [SerializeField] GameObject NormalWaveStatusImage;
    [SerializeField] GameObject BossWaveStatusImage;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        RefreshWaveStatus();
        GameManager.Instance.WaveClearEvent += RefreshWaveStatus;
        GameManager.Instance.StageClearEvent += ChangeWaveStatusImageToNormal;
    }

    public void RefreshWaveStatus()
    {
        WaveText.text = $"{GameManager.Instance.curWaveNum.ToString()} / {GameManager.Instance.targetWaveNum}";
    }

    public void ChangeWaveStatusImageToBoss()
    {
        NormalWaveStatusImage.SetActive(false);
        BossWaveStatusImage.SetActive(true);
    }

    public void ChangeWaveStatusImageToNormal()
    {
        Debug.Log("기본 이미지로 변경");
        NormalWaveStatusImage.SetActive(true);
        BossWaveStatusImage.SetActive(false);
    }
}
