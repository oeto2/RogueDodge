using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangeAttack : MonsterController
{


    protected override void Awake()
    {
        base.Awake();
        
    }
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
        
        if (distance <= monsterStats.attackRange && !monsterStats.IsAttacking)
        {
            CreateProjectil();
            StartCoroutine(AttackCooltime_CountDownCo());
        }
        else
        {
            monsterStats.eMONSTER_STATE = MONSTER_STATE.IDLE;
        }
    }



    IEnumerator AttackCooltime_CountDownCo()
    {
        monsterStats.eMONSTER_STATE = MONSTER_STATE.ATTACK;
        monsterStats.IsAttacking = true;
        float percent = 0;
        while (percent < monsterStats.attackCoolTime)
        {
            percent += Time.deltaTime;
            yield return null;
        }
        monsterStats.IsAttacking = false;
        monsterStats.eMONSTER_STATE = MONSTER_STATE.IDLE;

    }


}
