using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangeAttack : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;

    public float attackCooltime;
    public int attackListIdx = 0;
    delegate void RangeAttacks();

    RangeAttacks[] attackList = new RangeAttacks[5];

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        attackList[0] = CreateProjectil;
        attackList[1] = RoundShot;
    }
    private void Start()
    {
        monsterStats = monsterController.monsterStats;        

    }
   

    void Update()
    {
        if(monsterController.monsterStats.eMONSTER_STATE != MONSTER_STATE.DIE)
        {
            if(attackCooltime > monsterStats.attackCoolTime)
            {
             Check_PlayerInAttackBounder();
            }
            else
            {
                attackCooltime += Time.deltaTime*1;
            }
        }
    }


    void Check_PlayerInAttackBounder()
    {
        if (monsterController.distance <= monsterController.monsterStats.attackRange )
        {
            
            attackCooltime = 0;
            attackList[attackListIdx]();
            monsterController.CallOnAttackEvent();
            
        }
        else
        {
            monsterController.monsterStats.eMONSTER_STATE = MONSTER_STATE.IDLE;
        }
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
        float currentZ = transform.rotation.z;
        float angleStep = 360f / 10;
        for (int i = 0; i < 10; i++)
        {
            GameObject projectile = Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);
            projectile.GetComponent<MonsterProjectile>().SetMonsterStats(monsterStats);
            float angle = (i+currentZ) * angleStep;
            projectile.transform.Rotate(Vector3.forward, angle);
        }
    }
}
