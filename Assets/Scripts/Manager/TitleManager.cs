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
        SceneManager.LoadScene("ItemTest");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
