using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{

    //todo 상속 시키지말고 사용하기, 상속시키니까 개벼 이벤트로 처리됌
    public Rigidbody2D _rigidbody;
    public MonsterStats monsterStats;
    public Transform player;

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnAttackEvent;

    
    public float distance;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        monsterStats = GetComponent<MonsterStats>();
        player = GameManager.Instance.PlayerTransform;
    }

    void Update()
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
 

   
}
