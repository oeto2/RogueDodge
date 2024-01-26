using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MonsterStats))]
[RequireComponent(typeof(MonsterMovement))]
[RequireComponent(typeof(MonsterLifeCycle))]
[RequireComponent(typeof(MonsterAnimationController))]

public class MonsterController : MonoBehaviour
{
   
    public Rigidbody2D _rigidbody;
    public MonsterStats monsterStats;
    public Transform player;
    //public GameObject curMap;

    public event Action<Vector2> OnMoveEvent;
    public event Action OnAttackEvent;
    public event Action OnHitEvent;
    public event Action OnDeathEvent;


    
    public float distance;
    public Vector2 dir;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        monsterStats = GetComponent<MonsterStats>();
        
    }

    void Start()
    {
        player = GameManager.Instance.PlayerTransform;
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);
        dir = (player.position - transform.position).normalized;
    }


    public void CallOnMoveEvent(Vector2 _dir)
    {
        OnMoveEvent?.Invoke(_dir);
    }
    public void CallOnAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
    public void CallOnHitEvent()
    {
        OnHitEvent?.Invoke();
    }
    public void CallOnDeathEvent()
    {
        OnDeathEvent?.Invoke();
    }


}
