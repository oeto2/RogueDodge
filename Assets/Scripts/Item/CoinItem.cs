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
        if (Physics2D.OverlapCircle(transform.position, range, mask))
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
            Destroy(gameObject);
            Debug.Log("Coin Get");
        }
    }


    IEnumerator SpawnCoinCo()
    {
        _rigidbody.gravityScale = 1;
        _rigidbody.AddForce(Vector2.up*300*Time.deltaTime, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = Vector2.zero;
    }
}
