using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int mapX = 0;
    private bool isUsed = false;

    [SerializeField] Vector3[] itemSpawn;
    //map1 (-8, -2.4) (-3, 4.6), (3.-2.4), (5, 7.6) (10, 2.5)
    //map2 (-9.6, 15.5) (8, 15.5) (-9, 5.5) (8, 5.5) (14, -2.5)
    //map3 (-12,9.6), (13,9.6) (1, 3.6) (-12, -2.4), (13, -2.4)

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isUsed)
        {
            MapCreator.I.CreateNextMap(gameObject);
            isUsed = true;
        }
    }
}
