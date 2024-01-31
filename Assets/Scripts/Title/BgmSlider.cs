using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSlider : MonoBehaviour
{
    Slider BgmSliderComp;

    private void Awake()
    {
        BgmSliderComp = gameObject.GetComponent<Slider>();
        BgmSliderComp.value = TitleInfoManager.Instance.bgmVolume;
    }

    private void Start()
    {
        RefreshSliderValue();
    }

    public void RefreshSliderValue()
    {
        BgmSliderComp.value = TitleInfoManager.Instance.bgmVolume;
    }
}
