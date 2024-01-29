using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    [SerializeField] Slider HpSlider;

    public void ApplyDamageToPlayerHpUI(int _maxHp, int _currentHp, float _damge)
    => HpSlider.value = (float)(_currentHp - _damge) / _maxHp;

    public void ApplyHealToPlayerHpUI(int _maxHp, int _currentHp, float _healValue)
    => HpSlider.value = (float)(_currentHp + _healValue) / _maxHp;
}
