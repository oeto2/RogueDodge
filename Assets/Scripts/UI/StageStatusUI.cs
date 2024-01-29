using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStatusUI : MonoBehaviour
{
    [SerializeField] Text WaveText;

    public void Start()
    {
        RefreshWaveStatus();
        GameManager.Instance.WaveClearEvent += RefreshWaveStatus;

    }

    public void RefreshWaveStatus()
    {
        WaveText.text = $"{GameManager.Instance.curWaveNum.ToString()} / {GameManager.Instance.targetWaveNum}";
    }
}
