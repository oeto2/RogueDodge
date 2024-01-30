using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSlider : MonoBehaviour
{
    Slider EffectSliderComp;

    private void Awake()
    {
        EffectSliderComp = gameObject.GetComponent<Slider>();
        EffectSliderComp.value = TitleInfoManager.Instance.bgmVolume;
    }

    private void Start()
    {
        RefreshSliderValue();
    }

    public void RefreshSliderValue()
    {
        EffectSliderComp.value = TitleInfoManager.Instance.effectVolume;
    }
}
