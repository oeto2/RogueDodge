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
    MonsterController monsterController;

    readonly int IsOpenning = Animator.StringToHash("boss_openning");
    readonly int IsAttack_1 = Animator.StringToHash("attack_1");
    readonly int IsAttack_2 = Animator.StringToHash("attack_2");
    delegate void AttackPattern();
    public  List<ParticleSystem> attackEffect = new List<ParticleSystem>();
    List<AttackPattern> attackPatterns = new List<AttackPattern>();

    System.Random random;
  
    GameObject player;
    int attackCooltime;
    int collisionDamage;
    float atk;


    public GameObject monster;
    public GameObject spawn;
    public Transform SpanwMonsterHolder;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bossUi = GetComponent<BossMonsterUIController>();
        monsterController= GetComponent<MonsterController>(); 
        random = new System.Random();
        //monsterController.OnDeathEvent += DomeMonsterAllDie;

        EffectOff();
    }
    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        
        attackPatterns.Add(AttackPattern_1);
        attackPatterns.Add(AttackPatern_2_SpawnMonster);

        player = GameManager.Instance.PlayerTransform.gameObject;

        StartCoroutine(OnAttackCo());
    }

    void EffectOff()
    {
        foreach(ParticleSystem par in attackEffect)
        {
            par.Stop();
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


    void AttackPattern_1() // �����
    {
        Vector2 dir = monsterController.dir;
        attackEffect[0].Play();
        ParticleSystem.VelocityOverLifetimeModule velocity;
        velocity = attackEffect[0].velocityOverLifetime;
        velocity.x = dir.x*-5;
        attackCooltime = 2;
        
        //int defaultCollisionDamge = monsterStats.collisionDamage;
        int collisionDamage = 15;
        monsterStats.collisionDamage = collisionDamage;
        Vector2 playerPosition = player.transform.position;
        StartCoroutine(AttackPattern_1Co(playerPosition));
        //monsterStats.collisionDamage = defaultCollisionDamge;
        
    }
    IEnumerator AttackPattern_1Co(Vector2 playerPosition) //1 second
    {
        float parcent = 0;
        animator.SetTrigger(IsAttack_1);
        while (parcent < 1)
        {
            parcent += Time.deltaTime * 0.5f;
            _rigidbody.position = Vector2.Lerp(transform.position, playerPosition, parcent);
            yield return null;
        }
        attackEffect[0].Stop();
    }

    void AttackPatern_2_SpawnMonster()
    {
        attackCooltime = 3;
        Vector2 center = transform.position;
        animator.SetTrigger(IsAttack_2);
        StartCoroutine(AttackPatern_2_SpawnMonsterCo(center));

    }
    IEnumerator AttackPatern_2_SpawnMonsterCo(Vector2 center) //2.5 second
    {
        
        float parcent = 0;
        while(parcent < 1)
        {
            parcent += 0.2f;
            float randomRadian = Random.Range(0f, 2f * Mathf.PI);
            float x = center.x + 1f * Mathf.Cos(randomRadian);
            float y = center.y + 1f * Mathf.Sin(randomRadian);
            Destroy(Instantiate(spawn, new Vector2(x, y), Quaternion.identity),.5f);
            yield return new WaitForSeconds(0.4f);
            GameObject _monster = Instantiate(monster, new Vector2(x, y), Quaternion.identity);
            _monster.GetComponent<MonsterStats>().eMONSTER_WD = MONSTER_WD.DOME;
            _monster.transform.SetParent(SpanwMonsterHolder);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void DomeMonsterAllDie()
    {
        GameObject[] objs = new GameObject[SpanwMonsterHolder.childCount];
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i] = SpanwMonsterHolder.GetChild(i).gameObject;
        }

        foreach(GameObject obj in objs)
        {
            obj.GetComponent<MonsterStats>().hp = 0;
            obj.GetComponent<MonsterController>().CallOnHitEvent();
        }
    }

 

 
    
}
