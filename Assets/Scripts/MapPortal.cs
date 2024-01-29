using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPortal : MonoBehaviour
{
    bool isUsed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.CompareTag("MapPortal"))
        {
            if(other.CompareTag("Player"))
            {
                
                GameManager.Instance.Teleport(false);
            }
        } else if(gameObject.CompareTag("ShopPortal"))
        {
            if (other.CompareTag("Player") && !isUsed)
            {
                MapCreator.instance.CreateNextMap();
                isUsed = true;
            }
        }
        
    }
}
