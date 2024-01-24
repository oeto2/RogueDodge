using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnAttackEvent;
    public MonsterStats monsterStats;
    public float distance;
    public Transform player;
    public Vector2 dir = Vector2.zero;

    public Rigidbody2D _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        player = GameManager.Instance.player;
    }

    protected virtual void Update()
    {
        if(monsterStats.eMONSTER_STATE == MONSTER_STATE.ATTACK && !monsterStats.IsAttacking)
        {
            //발사체 생성
            //Todo
            //Todo
            //Todo
        }
    }


    public void CallOnMoveEvent(Vector2 _dir)
    {
        OnMoveEvent?.Invoke(_dir);
    }
    public void CallOnAttackEvent(Vector2 _dir)
    {
        OnAttackEvent?.Invoke(_dir);
    }



    public void CreateProjectil(Vector2 dir)
    {
        Instantiate(monsterStats.projectile, monsterStats.projectileSpawner.position, Quaternion.identity);

    }
}
