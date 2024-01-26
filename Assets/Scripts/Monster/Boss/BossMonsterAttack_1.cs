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

    int attackCooltime; //���� ���ϸ��� �����Ҷ� ������Ÿ�� �����Ű��, �ڷ�ƾ �Ҷ����� ������Ʈ�� ����
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


    void AttackPattern_1() // ������
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
