using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //TODO: Change to ButtonClicked
            MapCreator.instance.CreateNextMap();
            isUsed = true;
        }
    }
}
