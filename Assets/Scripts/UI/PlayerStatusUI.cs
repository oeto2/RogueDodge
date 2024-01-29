using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] Text PlayerATK_Text;
    [SerializeField] Text PlayerATKCoolTime_Text;
    [SerializeField] Text PlayerSpeed_Text;

    public void Start()
    {
        RefreshPlayerStatusUI();
        ItemManager.Instance.GetItemAfterEvent += RefreshPlayerStatusUI;
    }

    public void RefreshPlayerStatusUI()
    {
        PlayerStats playerStatusScript = GameManager.Instance.player.GetComponent<PlayerStats>();

        PlayerATK_Text.text = playerStatusScript.getAtk.ToString();
        PlayerATKCoolTime_Text.text = playerStatusScript.getAtkCoolTime.ToString();
        PlayerSpeed_Text.text = playerStatusScript.getSpeed.ToString();
    }
}
