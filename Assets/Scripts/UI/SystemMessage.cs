using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMessage : MonoBehaviour
{
    [SerializeField] Text SystemMessage_Text;
    [SerializeField] GameObject SystemMessage_Object;
    [SerializeField] [Range(1f, 5f)] float closeSystemMessageDealyTime = 3f;

    public void Start()
    {
        GameManager.Instance.WaveClearEvent += PrintWaveClearMessage;
        GameManager.Instance.StageClearEvent += PrintStageClearMessage;
    }

    public void PrintWaveClearMessage()
    {
        SystemMessage_Text.text = "WAVE CLEAR!";
        StartCoroutine(StartSystemMessageAnimation());
    }

    public void PrintStageClearMessage()
    {
        SystemMessage_Text.text = "STAGE CLEAR!";
        StartCoroutine(StartSystemMessageAnimation());
    }

    public void PrintSystemMessage(string _message)
    {
        SystemMessage_Text.text = _message;
    }

    IEnumerator StartSystemMessageAnimation()
    {
        SystemMessage_Object.SetActive(true);
        yield return new WaitForSeconds(closeSystemMessageDealyTime);
        SystemMessage_Object.SetActive(false);
    }
}
