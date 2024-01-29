using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.CompareTag("MapPortal") && !isUsed)
        {
            if(other.CompareTag("Player"))
            {
                GameManager.Instance.Teleport(false);
                isUsed = true;
            }
        } else if(gameObject.CompareTag("ShopPortal"))
        {
            if (other.CompareTag("Player"))
            {
                MapCreator.instance.CreateNextMap();
            }
        }
        
    }
}
