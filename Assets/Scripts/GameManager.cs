using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance = null;
    //test
    public Transform player;
    //
    private int gold { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
        //test
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //
    }

}
