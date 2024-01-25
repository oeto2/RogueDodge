using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public MonsterStats monsterStats;
    public Transform player;

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnAttackEvent;

    
    public float distance;
    public Vector2 dir = Vector2.zero;
    

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        player = GameManager.Instance.PlayerTransform;
    }

    protected virtual void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        
    }


    public void CallOnMoveEvent(Vector2 _dir)
    {
        OnMoveEvent?.Invoke(_dir);
    }
    public void CallOnAttackEvent(Vector2 _dir)
    {
        OnAttackEvent?.Invoke(_dir);
    }
 

    public void CreateProjectil()
    {
        Vector2 lookDir = (player.position - monsterStats.projectileSpawner.position).normalized;
        GameObject projectile= Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);
        projectile.GetComponent<MonsterProjectile>().SetDir(lookDir);
        projectile.GetComponent<MonsterProjectile>().SetMonsterStats(monsterStats);
    }
}
