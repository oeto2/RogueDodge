using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterAttack_1 : MonoBehaviour
{
    //Componets
    Rigidbody2D _rigidbody;
    Animator animator;
    MonsterStats monsterStats;
    BossMonsterUIController bossUi;

    readonly int IsOpenning = Animator.StringToHash("boss_openning");
    readonly int IsAttack_1 = Animator.StringToHash("attack_1");

    delegate void AttackPattern();
    List<AttackPattern> attackPatterns = new List<AttackPattern>();
    System.Random random;
  
    GameObject player;

    int attackCooltime; //어택 패턴마다 시작할때 어택쿨타임 변경시키고, 코루틴 할때마다 뉴세컨트에 설정
    int collisionDamage;
    float atk;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bossUi = GetComponent<BossMonsterUIController>();
        random = new System.Random();
    }
    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        attackPatterns.Add(AttackPattern_1);
        player = GameManager.Instance.PlayerTransform.gameObject;

        StartCoroutine(OnAttackCo());
    }


    void AttackPattern_1() // 돌진기
    {
        attackCooltime = 3;
        //int defaultCollisionDamge = monsterStats.collisionDamage;
        int collisionDamage = 15;
        monsterStats.collisionDamage = collisionDamage;
        Vector2 playerPosition = player.transform.position;
        StartCoroutine(AttackPattern_1Co(playerPosition));
        //monsterStats.collisionDamage = defaultCollisionDamge;
        
    }
    IEnumerator AttackPattern_1Co(Vector2 playerPosition)
    {
        float parcent = 0;
        animator.SetTrigger(IsAttack_1);
        while (parcent < 1)
        {
            parcent += Time.deltaTime * 0.5f;
            _rigidbody.position = Vector2.Lerp(transform.position, playerPosition, parcent);
            yield return null;
        }
    }

    IEnumerator OnAttackCo()
    {
        animator.SetTrigger(IsOpenning);
        bossUi.SetActiveUi();
        yield return new WaitForSeconds(2);

        while (monsterStats.eMONSTER_STATE != MONSTER_STATE.DIE)
        {
            int idx = random.Next(0, attackPatterns.Count);
            AttackPattern attack = attackPatterns[idx];
            attack();
            yield return new WaitForSeconds(attackCooltime);
        }
    }

 
    
}
