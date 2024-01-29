using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBgmManager : MonoBehaviour
{
    public static MainBgmManager Instance;
    public AudioClip[] StageBgmList;
    public AudioClip BossBgm;
    public AudioClip ShopBgm;
    AudioSource BgmAudioSource;

    private void Awake()
    {
        Instance = this;
        BgmAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void Start()
    {
        SetVolumeFromTitleInfo();
        //Player Stage1 BGM
        PlayStageBGM(1);
    }

    public void PlayStageBGM(int _stageNumber)
    {
        BgmAudioSource.clip = StageBgmList[_stageNumber - 1];
        BgmAudioSource.Play();
    }

    public void PlayBossBgm()
    {
        BgmAudioSource.clip = BossBgm;
        BgmAudioSource.Play();
    }

    public void PlayShopBgm()
    {
        BgmAudioSource.clip = ShopBgm;
        BgmAudioSource.Play();
    }

    public void SetVolumeFromTitleInfo()
    {
        if (TitleInfoManager.Instance != null)
            BgmAudioSource.volume = TitleInfoManager.Instance.bgmVolume;
    }
}
