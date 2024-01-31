using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] Text PlayerATK_Text;
    [SerializeField] Text PlayerATKCoolTime_Text;
    [SerializeField] Text PlayerSpeed_Text;
    [SerializeField] Text PlayerGold_Text;

    public void Start()
    {
        StartCoroutine(RefreshPlayerGoldTextDealy());
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

    public void RefreshPlayerGoldText()
    {
        PlayerItemLoot playerItemLootScripts = GameManager.Instance.player.GetComponent<PlayerItemLoot>();
        PlayerGold_Text.text = playerItemLootScripts.getCoin.ToString();
    }

    IEnumerator RefreshPlayerGoldTextDealy()
    {
        yield return new WaitForSeconds(0.1f);
        RefreshPlayerGoldText();
    }
}
