using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Event call when player get item
        if (collision.CompareTag("Player"))
        {
            ItemManager.Instance.CallGetItemEvnet();
        }
    }

    public void PrintGetItemMessage()
    {

    }    
}
