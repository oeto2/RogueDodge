using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    public void StartGame()
    {
        //Todo
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}
