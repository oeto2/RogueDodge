using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifeCycle : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;
    BoxCollider2D collider;
    Player player;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        collider = GetComponent<BoxCollider2D>();
        monsterController.OnHitEvent += Hit;
        monsterController.OnDeathEvent += Death;
    }

    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        player = monsterController.player.GetComponent<Player>(); //todo
    }

    void Hit(float damage)
    {
        monsterStats.hp -= (int)damage;
        monsterController.CallOnDeathEvent();
    }



    void Death()
    {
        if(monsterStats.hp <= 0)
        {
            monsterStats.eMONSTER_STATE = MONSTER_STATE.DIE;
            collider.enabled = false;
        }
    }

}
