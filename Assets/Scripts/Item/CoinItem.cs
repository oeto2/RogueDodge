using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    //오버랩으로 플레이어 탐지, 탐지시 플레이어 방향으로 이동.

    Rigidbody2D _rigidbody;
    Transform player;
    
    Vector2 dir;
    public LayerMask mask;
    public float range;
    public float chaseSpeed;

    bool IsChase;
    bool IsSpawning =true;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        player = GameManager.Instance.PlayerTransform;
        StartCoroutine(SpawnCoinCo());
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, range, mask)&&!IsSpawning)
        {
            IsChase = true;
        }
        if(IsChase == true)
        {
            dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)dir * Time.deltaTime*chaseSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerTransform.gameObject.GetComponent<PlayerItemLoot>().getCoin=1;
            Debug.Log(GameManager.Instance.PlayerTransform.gameObject.GetComponent<PlayerItemLoot>().getCoin);
            Destroy(gameObject);
           
        }
    }


    IEnumerator SpawnCoinCo()
    {
        float z = Random.Range(0, Mathf.PI);
        Vector2 position = new Vector2(Mathf.Cos(z)*2, Mathf.Sin(z)*2);

        _rigidbody.gravityScale = 0.5f;
        _rigidbody.AddForce(position*20, ForceMode2D.Force);
        yield return new WaitForSeconds(0.8f);
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.5f);
        IsSpawning = false;
    }
}
