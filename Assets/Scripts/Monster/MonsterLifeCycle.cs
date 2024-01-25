using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifeCycle : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;
    BoxCollider2D collider;
    //Player player;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        collider = GetComponent<BoxCollider2D>();
        monsterController.OnHitEvent += Hit;
    }

    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        //player = monsterController.player.GetComponent<Player>(); //todo
    }

    void Hit(float damage)
    {
        monsterStats.hp -= (int)damage;
        Death();
    }

    void Death()
    {
        if(monsterStats.hp <= 0)
        {
            monsterStats.eMONSTER_STATE = MONSTER_STATE.DIE;
            collider.enabled = false;
            monsterController.CallOnDeathEvent();
            Destroy(gameObject, 1f);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision) //todo
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            monsterController.CallOnHitEvent(5);
        }
    }



}
