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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !isUsed)
        {
            MapCreator.instance.CreateNextMap(gameObject);
            isUsed = true;
        }
    }
}
