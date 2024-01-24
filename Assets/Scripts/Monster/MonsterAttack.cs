using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterController
{
    Vector2 dir = Vector2.zero;
    Transform player;

    private void Awake()
    {
        monsterStats = GetComponent<MonsterStats>();
    }
    protected override void Start()
    {
        base.Start();
        player = GameManager.Instance.player;
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
            //함수
        }
    }

    IEnumerator AttackCooltime_CountDownCo()
    {
        float percent = 0;
        while (percent < monsterStats.attackCoolTime)
        {
            percent += Time.deltaTime;
            yield return null;
        }

    }


}
