using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleBgmManager : MonoBehaviour
{
    [SerializeField] AudioClip TitleBGM;
    AudioSource BGMAudioSource;
    [SerializeField] Slider BgmVolumeSlider;

    private void Awake()
    {
        BGMAudioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartTitleBGM();
        SetBgmVoulme();
    }

    public void StartTitleBGM()
    {
        BGMAudioSource.clip = TitleBGM;
        BGMAudioSource.Play();
    }

    public void SetBgmVolumeFromSlider()
    {
        BGMAudioSource.volume = BgmVolumeSlider.value;
        TitleInfoManager.Instance.bgmVolume = BgmVolumeSlider.value;
    }

    public void SetBgmVoulme()
    {
        BGMAudioSource.volume = TitleInfoManager.Instance.bgmVolume;
    }
}
