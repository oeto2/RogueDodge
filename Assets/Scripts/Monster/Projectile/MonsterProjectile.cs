using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    public Vector2 dir = Vector2.right;
    Rigidbody2D _rigidbody;

    public float projectileSpeed;


    public MonsterStats monsterStats;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _rigidbody.position += dir * projectileSpeed * Time.deltaTime;
    }


    public void SetDir(Vector2 _dir)
    {
        dir = _dir;
    }
    public void SetMonsterStats(MonsterStats _monsterStats)
    {
        monsterStats = _monsterStats;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            Destroy(gameObject);
            //todo -Create ObjectPool, Recycling projectile 
        }

    }
}
