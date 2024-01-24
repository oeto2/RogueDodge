using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonsterController
{
    //
    Rigidbody2D rigidbody;

    public Transform player;

    //move
    public MonsterStats monsterStats;

    Vector2 dir = Vector2.zero;

    private void Awake()
    {
        monsterStats = GetComponent<MonsterStats>();
        rigidbody = GetComponent<Rigidbody2D>();
        

    }
    private void Start()
    {
        player = GameManager.Instance.player;
        OnMoveEvent += Move;
    }

    private void Update()
    {
        CheckPlayerDistance();
    }

    private void FixedUpdate()
    {
        
        MoveAction();
    }

    void Move(Vector2 _dir)
    {
        rigidbody.position += _dir * Time.deltaTime * monsterStats.speed;
        for (int i = 0; i < monsterStats.spriteRendererss.Length; i++)
        {
            monsterStats.spriteRendererss[i].flipX = _dir.x > 0;
        }
    }



    void MoveAction()
    {
        Vector2 dir = (player.position - transform.position).normalized;
        if (monsterStats.eMONSTER_STATE == MONSTER_STATE.CHASE)
        {
            CallOnMoveEvent(dir);
        }else if(monsterStats.eMONSTER_STATE == MONSTER_STATE.RUNAWAY)
        {
            //CallOnMoveEvent(-dir);
        }
    }


    void CheckPlayerDistance() // 
    {
        float distance = Vector3.Distance(player.position, transform.position);
       
           if (distance < monsterStats.followRange)
           {
            monsterStats.eMONSTER_STATE = MONSTER_STATE.CHASE;
           }
        
        
    }

  


}
