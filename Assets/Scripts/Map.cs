using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int mapX = 0;
    public int mapY = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if(other.tag == "Player")
        {
            MapCreator.I.CreateNextMap(mapX);
        }
    }
}
