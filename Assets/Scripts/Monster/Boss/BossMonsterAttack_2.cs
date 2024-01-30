using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    readonly int IsAttack_3 = Animator.StringToHash("attack_3");


    delegate void AttackPattern();
    List<AttackPattern> attackPatterns = new List<AttackPattern>();
    public List<GameObject> attackEffects = new List<GameObject>();

    public List<GameObject> projectils = new List<GameObject>();

    public GameObject visibleAttackPoint;
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
        attackPatterns.Add(AttackPattern_3);
        player = GameManager.Instance.PlayerTransform.gameObject;

        StartCoroutine(OnAttackCo());
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
        Vector2 matorSpawnPoint = monsterController.player.position;
        matorSpawnPoint.x += 5;
        matorSpawnPoint.y += 5;
        animator.SetTrigger(IsAttack_3);
        attackEffects[2].SetActive(true);
        StartCoroutine(AttackPattern_3Co(matorSpawnPoint));


    }

    IEnumerator AttackPattern_3Co(Vector2 spawnPoint) // 4 second
    {
        Coord[] coords = new Coord[10];

        for (int i = 0; i < 10; i++) 
        {
            float randomZAngle = Random.Range(0, Mathf.PI * 2);
            float randomDistance = (float)random.NextDouble() * 5 + 1;
            float x = monsterController.player.position.x + randomDistance * Mathf.Cos(randomZAngle);
            float y = monsterController.player.position.y + randomDistance * Mathf.Sin(randomZAngle);
            coords[i] = new Coord(new Vector2(x, y));

            Destroy(Instantiate(visibleAttackPoint, new Vector2(x,y), Quaternion.identity), 1f);
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine(MatorActiveCo(coords));
    }
    IEnumerator MatorActiveCo(Coord[] coords) 
    {
        Vector3 matorSpawnPoint = (Vector2)monsterController.player.position + new Vector2(5, 10);
        foreach(Coord coord in coords)
        {
            GameObject projectile = Instantiate(projectils[0],matorSpawnPoint, Quaternion.identity);
            projectile.GetComponent<FireBallProjectile>().SetTargetPosition(new Vector2(coord.X, coord.Y), true);
            yield return new WaitForSeconds(0.2f);
        }
        attackEffects[2].SetActive(false);

    }
   // 도트대미지 구현,


    struct Coord
    {
        public float X;
        public float Y;

        public Coord(Vector2 coord)
        {
            X = coord.x;
            Y = coord.y;
        }
    }

}
