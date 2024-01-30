using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShakeLight : MonoBehaviour
{
    Light2D Light;
    [SerializeField] float Minbrightness;
    [SerializeField] float Maxbrightness;
    [SerializeField] [Range(1f, 3f)] float ShakeValue = 1f;

    [SerializeField] bool expandLight = true;

    private void Awake()
    {
        Light = gameObject.GetComponent<Light2D>();
    }

    private void Update()
    {
        StartShakeLight();
    }
    
    public void StartShakeLight()
    {
        Debug.Log(Minbrightness +  " " + Maxbrightness);
        //Set bool expandLight
        SetExpandLight();

        if (expandLight)
            Light.falloffIntensity += ShakeValue * Time.deltaTime *0.1f;
        else
            Light.falloffIntensity -= ShakeValue * Time.deltaTime * 0.1f;
    }

    public void SetExpandLight()
    {
        if (Light.falloffIntensity >= Maxbrightness)
            expandLight = false;
        else if (Light.falloffIntensity <= Minbrightness)
            expandLight = true;
    }
}
