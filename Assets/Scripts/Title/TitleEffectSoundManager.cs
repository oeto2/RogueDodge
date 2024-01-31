using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleEffectSoundManager : MonoBehaviour
{
    [SerializeField] AudioClip ButtonClickSound;
    AudioSource TitleEffectAudioSource;
    [SerializeField] Slider TitleEffectSoundVolume_Slider;

    private void Awake()
    {
        TitleEffectAudioSource = this.gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        SetEffectVoulme();
    }


    public void PlayButtonClickSound() => TitleEffectAudioSource.PlayOneShot(ButtonClickSound);

    public void SetTitleEffectVolumeFromSlider()
    {
        TitleEffectAudioSource.volume = TitleEffectSoundVolume_Slider.value;
        TitleInfoManager.Instance.effectVolume = TitleEffectSoundVolume_Slider.value;
    }

    public void SetEffectVoulme()
    {
        TitleEffectAudioSource.volume = TitleInfoManager.Instance.bgmVolume;
    }
}
