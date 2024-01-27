using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterAttack_2 : MonoBehaviour
{
    //Componets
    Rigidbody2D _rigidbody;
    Animator animator;
    MonsterStats monsterStats;
    BossMonsterUIController bossUi;
    MonsterController monsterController;

    readonly int IsOpenning = Animator.StringToHash("boss_openning");
    readonly int IsAttack_1 = Animator.StringToHash("attack_1");
    readonly int IsAttack_2 = Animator.StringToHash("attack_2");
    delegate void AttackPattern();
    public List<GameObject> attackEffects = new List<GameObject>();
    List<AttackPattern> attackPatterns = new List<AttackPattern>();

    public List<GameObject> projectils = new List<GameObject>();

    System.Random random;

    GameObject player;
    int attackCooltime;
    int collisionDamage;
    float atk;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bossUi = GetComponent<BossMonsterUIController>();
        monsterController = GetComponent<MonsterController>();
        random = new System.Random();
    }
    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        attackPatterns.Add(AttackPattern_1);
        attackPatterns.Add(AttackPattern_2);
        player = GameManager.Instance.PlayerTransform.gameObject;

        StartCoroutine(OnAttackCo());
    }

    IEnumerator OnAttackCo()
    {
        animator.SetTrigger(IsOpenning);
        //bossUi.SetActiveUi();
        yield return new WaitForSeconds(2);

        while (monsterStats.eMONSTER_STATE != MONSTER_STATE.DIE)
        {
            int idx = random.Next(0, attackPatterns.Count);
            AttackPattern attack = attackPatterns[idx];
            attack();
            yield return new WaitForSeconds(10);
        }
    }



    void AttackPattern_1() // 나선형
    {
        animator.SetTrigger(IsAttack_1);
        attackEffects[0].SetActive(true);
        StartCoroutine(SpiralShotCo(4));
    }
    IEnumerator SpiralShotCo(float duration) //4 second
    {
        float percent = 0;
        float angle = Mathf.Atan2(monsterController.dir.y, monsterController.dir.x) * Mathf.Rad2Deg - 50;
        while (percent < duration)
        {
            angle += 10;
            percent += 0.1f;
            GameObject projectile = Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);
            projectile.GetComponent<MonsterProjectile>().SetMonsterStats(monsterStats);
            projectile.transform.Rotate(Vector3.forward, angle);

            yield return new WaitForSeconds(0.1f);
        }
        attackEffects[0].SetActive(false);
    }

    void AttackPattern_2() // 연사
    {
        animator.SetTrigger(IsAttack_2);
        attackEffects[1].SetActive(true);
        StartCoroutine(AttackPattern_2Co());
    }
    IEnumerator AttackPattern_2Co() //1.2 second
    {
        for (int i = 0; i< 4; i++)
        {
            float ranY = random.Next(-1, 1);
            Vector2 spawnPoint = monsterStats.projectileSpawner.position;
            spawnPoint.y += ranY;
            GameObject projectile = Instantiate(projectils[0],spawnPoint, Quaternion.identity);
            projectile.GetComponent<FireBallProjectile>().SetTargetPosition(monsterController.player.position, false);
            yield return new WaitForSeconds(0.3f);
        }
        attackEffects[1].SetActive(false);
    }

    void AttackPattern_3() // 메테오
    {

    }

   // 연사, 메테오, 도트대미지 구현, 
}
