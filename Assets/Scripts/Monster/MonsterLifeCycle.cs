using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifeCycle : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;
    BoxCollider2D _collider;
    //Player player;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        _collider = GetComponent<BoxCollider2D>();
        monsterController.OnHitEvent += Hit;
    }

    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        //player = monsterController.player.GetComponent<Player>(); //todo
    }

    void Hit()
    {
        Death();
    }

    void Death()
    {
        if(monsterStats.hp <= 0)
        {
            monsterStats.hp = 0;
            monsterStats.eMONSTER_STATE = MONSTER_STATE.DIE;
            _collider.enabled = false;

            switch (monsterStats.eMONSTER_WD)//todo
            {
                case MONSTER_WD.BOSS: Debug.Log("BOSS");
                    // gameManager gameClear;
                    GameManager.Instance.WaveClear();
                    break;
                case MONSTER_WD.WILD: Debug.Log("WILD");
                    GameManager.Instance.AddDeadMonsterNum();
                    break;
                default: break;

            }

            monsterController.CallOnDeathEvent();
            Destroy(gameObject, 1f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            monsterController.CallOnHitEvent();
        }
    }



}
