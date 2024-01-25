using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangeAttack : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;

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
        Check_PlayerInAttackBounder();
    }


    void Check_PlayerInAttackBounder()
    {
        
        if (monsterController.distance <= monsterController.monsterStats.attackRange && !monsterController.monsterStats.IsAttacking)
        {
            CreateProjectil();
            monsterController.CallOnAttackEvent();
            StartCoroutine(AttackCooltime_CountDownCo());
        }
        else
        {
            monsterController.monsterStats.eMONSTER_STATE = MONSTER_STATE.IDLE;
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

    public void CreateProjectil()
    {
        Vector2 lookDir = (monsterController.player.position - monsterStats.projectileSpawner.position).normalized;
        GameObject projectile = Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);
        projectile.GetComponent<MonsterProjectile>().SetDir(lookDir);
        projectile.GetComponent<MonsterProjectile>().SetMonsterStats(monsterStats);

    }


    public void RoundShot()
    {
        float angleStep = 360f / 10;
        for (int i = 0; i < 10; i++)
        {
            GameObject projectile = Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);
            float angle = i * angleStep;
            projectile.transform.Rotate(Vector3.forward, angle);
        }
    }
}
