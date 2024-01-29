using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int mapX = 0;
    private bool isUsed = false;

    public Vector3[] itemSpawn;
    //map1 (-3, 3.6) (0.5, 3.6) (4, 3.6)
    //map2 (-5, 3.6) (-0.5, 3.6)(4, 3.6)
    //map3 (-3, 9.6) (0.5 10.6) (4, 9.6) 

    [SerializeField] GameObject portal;
    [SerializeField] GameObject itemSpawnPoint;

    private void Start()
    {
        GameManager.Instance.StageClearEvent += ShowPortal;
        GameManager.Instance.WaveClearEvent += ShowItemSpawnPoint;
    }

    void ShowPortal()
    {
        portal.SetActive(true);
    }

    void ShowItemSpawnPoint()
    {
        itemSpawnPoint.SetActive(true);
    }
}
