using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterController
{

   
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Check_PlayerInAttackBounder();
    }


    void Check_PlayerInAttackBounder()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < monsterStats.attackRange)
        {
            monsterStats.eMONSTER_STATE = MONSTER_STATE.ATTACK;
            //Todo
            //Todo
            //Todo
            StartCoroutine(AttackCooltime_CountDownCo());

        }
        else
        {
            //Todo
            //Todo
            //Todo
            monsterStats.eMONSTER_STATE = MONSTER_STATE.IDLE;
        }
    }

    IEnumerator AttackCooltime_CountDownCo()
    {
        monsterStats.IsAttacking = true;
        float percent = 0;
        while (percent < monsterStats.attackCoolTime)
        {
            percent += Time.deltaTime;
            yield return null;
        }
        monsterStats.IsAttacking = false;

    }


}
