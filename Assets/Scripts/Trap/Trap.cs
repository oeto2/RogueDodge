using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum TrapDir
{
    RIGHT, LEFT, UP, DOWN
}

public class Trap : MonoBehaviour
{
    public TrapDir trapDir = TrapDir.RIGHT;
    public int rayLength;
    RaycastHit2D hit;

    public LayerMask target;


    private void Update()
    {
        switch (trapDir)
        {
            case TrapDir.RIGHT:
                hit = Physics2D.Raycast(transform.position, Vector2.right, rayLength,target);
                
                break;
            case TrapDir.LEFT:
                hit = Physics2D.Raycast(transform.position, Vector2.left, rayLength, target);
                
                break;
            case TrapDir.UP:
                hit = Physics2D.Raycast(transform.position, Vector2.up, rayLength, target);
               
                break;
            case TrapDir.DOWN:
                hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, target);
               
                break;
        }

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player Hit");
            }
        }
    }
}
