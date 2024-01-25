using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMelleAttack : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;
    public GameObject hitBox;

    public float attackCooltime = 100;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
    }
    private void Start()
    {
        monsterStats = monsterController.monsterStats;
    }

    void Update()
    {
        if (monsterController.monsterStats.eMONSTER_STATE != MONSTER_STATE.DIE)
        {
            if (attackCooltime > monsterStats.attackCoolTime)
            {
                Check_PlayerInAttackBounder();
            }
            else
            {
                attackCooltime += Time.deltaTime * 1;
            }
        }
    }

    void Check_PlayerInAttackBounder()
    {
        if (monsterController.distance <= monsterController.monsterStats.attackRange)
        {
            hitBox.SetActive(true);
            attackCooltime = 0;
            monsterController.CallOnAttackEvent();

        }
        else
        {
            monsterController.monsterStats.eMONSTER_STATE = MONSTER_STATE.IDLE;
        }
    }


}
