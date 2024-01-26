using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum TRAP_DIR
{
    RIGHT, LEFT, UP, DOWN
}
public enum TRAP_TYPE
{
    TIME,
    SENTINEL
}

public class Trap : MonoBehaviour
{
    public TRAP_DIR eTRAP_DIR = TRAP_DIR.RIGHT;
    public TRAP_TYPE eTRAP_TYPE = TRAP_TYPE.TIME;

    public int rayLength;
    public int shotRate;
    RaycastHit2D hit;

    public LayerMask target;
    public GameObject projectile;




    private void Update()
    {
        switch (eTRAP_DIR)
        {
            case TRAP_DIR.RIGHT:
                hit = Physics2D.Raycast(transform.position, Vector2.right, rayLength,target);
                
                break;
            case TRAP_DIR.LEFT:
                hit = Physics2D.Raycast(transform.position, Vector2.left, rayLength, target);
                
                break;
            case TRAP_DIR.UP:
                hit = Physics2D.Raycast(transform.position, Vector2.up, rayLength, target);
               
                break;
            case TRAP_DIR.DOWN:
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

        //IEnumerator SentinelCo()
        //{

        //}




    }
}
