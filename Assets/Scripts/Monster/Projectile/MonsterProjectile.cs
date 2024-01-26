using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    public Vector2 dir = Vector2.right;
    Rigidbody2D _rigidbody;
   
    public float projectileSpeed;
    //public float damage = 0;

    public MonsterStats monsterStats;
    public GameObject particle_Spark;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.right * projectileSpeed * Time.deltaTime,ForceMode2D.Impulse);
    }


    public void SetDir(Vector2 _dir)
    {
        dir = _dir;
        float z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.Rotate(Vector3.forward, z);
    }
    public void SetMonsterStats(MonsterStats _monsterStats)
    {
        monsterStats = _monsterStats;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int damage = (int)monsterStats.atk;
            collision.gameObject.GetComponent<PlayerStats>().PlayerDamaged(damage);
            Destroy(gameObject);
            //todo -Create ObjectPool, Recycling projectile 
        }

    }
}
