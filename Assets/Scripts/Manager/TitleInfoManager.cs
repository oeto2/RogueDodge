using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInfoManager : MonoBehaviour
{
    public static TitleInfoManager Instance = null;

    [Range(0f,1f)] public float bgmVolume;
    [Range(0f, 1f)] public float effectVolume;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
    }

    public void SetBgmSoundVolumeInfo(float _volume) => bgmVolume = _volume;
    public void SetEffectSoundVolumeInfo(float _volume) => effectVolume = _volume;

}
