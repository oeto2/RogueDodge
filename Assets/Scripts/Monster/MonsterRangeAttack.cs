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
        attackList[2] = SpiralShot;
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
                monsterController.monsterStats.IsAttacking = false;
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
        if (monsterController.distance <= monsterController.monsterStats.attackRange && !monsterController.monsterStats.IsAttacking)
        {
            monsterController.monsterStats.IsAttacking = true;
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

    }//todo


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

    public void SpiralShot()
    {
        StartCoroutine(SpiralShotCo(2));
    }
   IEnumerator SpiralShotCo(float duration)
    {
        float percent = 0;
        float angle = Mathf.Atan2(monsterController.dir.y, monsterController.dir.x)*Mathf.Rad2Deg - 50;
        while(percent < duration)
        {
            angle += 10;
            percent += 0.1f;
            GameObject projectile = Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);
            projectile.GetComponent<MonsterProjectile>().SetMonsterStats(monsterStats);
            projectile.transform.Rotate(Vector3.forward, angle);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
