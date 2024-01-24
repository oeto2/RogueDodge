using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonsterController
{
    //
    Rigidbody2D rigidbody;

    public Transform player;
    SpriteRenderer spriteRenderer;

    //move
    public MonsterStats monsterStats;

    Vector2 dir = Vector2.zero;

    private void Awake()
    {
        monsterStats = GetComponent<MonsterStats>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameManager.Instance.player;

        OnMoveEvent += Move;
        OnLookEvent += Look;

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
        
    }


    void Look(Vector2 _dir)
    {
        spriteRenderer.flipX = _dir.x > 0;
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
       
            if (distance < monsterStats.runawayRange)
            {
                monsterStats.eMONSTER_STATE = MONSTER_STATE.RUNAWAY;
            }
            else if (distance < monsterStats.followRange)
            {
                CallOnLookEvent(dir);
                monsterStats.eMONSTER_STATE = MONSTER_STATE.CHASE;
            }
        
        
    }

  


}
