using System.Collections;
using System.Collections.Generic;
using TreeEditor;
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
    public float shotRate;
    public float shotCooltime;
    RaycastHit2D hit;
    public LayerMask target;
    public GameObject projectile;


    private void Awake()
    {
        ItemManager.Instance.GetItemAfterEvent += Sentinel;
    }

    private void Start()
    {
        shotCooltime = shotRate;
        switch (eTRAP_DIR)
        {
            case TRAP_DIR.LEFT:
                transform.right = -Vector2.right;
                break;
            case TRAP_DIR.UP:
                transform.right = Vector2.up;
                break;
            case TRAP_DIR.DOWN:
                transform.right = Vector2.down;
                break;
            default:
                transform.right = Vector2.right;
                break;
        }
        
        if(eTRAP_TYPE == TRAP_TYPE.TIME)
        {
            Sentinel();
        }
        
    }

    private void Update()
    {
        if(eTRAP_TYPE == TRAP_TYPE.SENTINEL)
        {
            switch (eTRAP_DIR)
            {
                case TRAP_DIR.RIGHT:
                    hit = Physics2D.Raycast(transform.position, Vector2.right, rayLength, target);

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
                    if(shotCooltime > shotRate)
                    {
                        shotCooltime = 0;
                        GameObject _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
                        _projectile.GetComponent<MonsterProjectile>().SetDir(transform.right);
                    }
                   
                }
            }
            shotCooltime += Time.deltaTime * 1;
        }
        
    }

    void Sentinel()
    {
        StartCoroutine(SentinelCo());
    }
    IEnumerator SentinelCo()
    {
        while (GameManager.Instance.eGameState == GAMESTATE.BATTLE)
        {
           GameObject _projectile = Instantiate(projectile,transform.position,Quaternion.identity);
            _projectile.GetComponent<MonsterProjectile>().SetDir(transform.right);
            yield return new WaitForSeconds(shotRate);
        }
    }
}
