using System.Collections;
using UnityEngine;

public class MonsterLifeCycle : MonoBehaviour
{
    MonsterController monsterController;
    MonsterStats monsterStats;
    BoxCollider2D _collider;
    //Player player;

    public GameObject coinObj;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        _collider = GetComponent<BoxCollider2D>();
        monsterController.OnHitEvent += Hit;
    }

    private void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
    }

    void Hit()
    {
        Death();
    }

    void Death()
    {
        if(monsterStats.hp <= 0 && monsterStats.eMONSTER_STATE != MONSTER_STATE.DIE)
        {
            monsterStats.hp = 0;
            monsterStats.eMONSTER_STATE = MONSTER_STATE.DIE;
            _collider.enabled = false;

            switch (monsterStats.eMONSTER_WD)//todo
            {
                case MONSTER_WD.BOSS: Debug.Log("BOSS");
                    // gameManager gameClear;
                    SpawnCoin(100, 10, 30);
                    GameManager.Instance.WaveClear();
                    break;
                case MONSTER_WD.WILD: Debug.Log("WILD");
                    GameManager.Instance.AddDeadMonsterNum();
                    SpawnCoin(20,1,5);
                    break;
                default: break;

            }

            monsterController.CallOnDeathEvent();
            Destroy(gameObject, 5f);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            monsterController.CallOnHitEvent();
        }
    }

    void SpawnCoin(int _percent, int minAmount,int maxAmount) //20
    {
        int percent = Random.Range(1, 101);
        if(percent <= _percent)
        {
           StartCoroutine(RandomAmount(minAmount,maxAmount));
        }
    }
    IEnumerator RandomAmount(int minAmount,int maxAmount)
    {
        int ran = Random.Range(minAmount, maxAmount);
        for (int i = 0; i < ran; i++)
        {
            Instantiate(coinObj, transform.position+Vector3.up, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }


}
