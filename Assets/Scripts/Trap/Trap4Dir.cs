using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap4Dir : MonoBehaviour
{
    public GameObject projectile;
    public float shotRate;



    private void Awake()
    {
        ItemManager.Instance.GetItemAfterEvent += ShotTrap;
    }
    private void Start()
    {
        ShotTrap();
    }



    void ShotTrap()
    {
        StartCoroutine(ShotTrapCo());
    }

    IEnumerator ShotTrapCo()
    {
        float z = 0;
        while(GameManager.Instance.eGameState == GAMESTATE.BATTLE)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject _projectile = Instantiate(projectile, transform.position, Quaternion.identity);
                _projectile.transform.Rotate(Vector3.forward, z + 90*i);
                _projectile.GetComponent<MonsterProjectile>().SetDir(transform.right);
                z += 2;
                
            }


            yield return new WaitForSeconds(shotRate);
        }
    }
}
