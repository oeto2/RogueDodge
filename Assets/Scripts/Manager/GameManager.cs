using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance = null;

    private int gold { get; set; }
    public Transform PlayerTransform;

    public GameObject curMap;
    public GameObject player;

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

        //TODO: if GameObject player is available -> delete
        PlayerTransform = GameObject.FindWithTag("Player").transform;

    }
}
