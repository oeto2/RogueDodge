using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonsterController
{
    
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start(); 

        OnMoveEvent += Move;
    }

    protected override void Update()
    {
        base.Update();
        CheckPlayerDistance();
    }

    private void FixedUpdate()
    {
        if(monsterStats.eMONSTER_STATE != MONSTER_STATE.ATTACK)
        {
            MoveAction();
        }
    }

    void Move(Vector2 _dir)
    {
        _rigidbody.position += _dir * Time.deltaTime * monsterStats.speed;
        for (int i = 0; i < monsterStats.spriteRendererss.Length; i++)
        {
            monsterStats.spriteRendererss[i].flipX = _dir.x > 0;
        }
    }



    void MoveAction()
    {
        CallOnMoveEvent(dir);
        //Todo
        //Todo
    }


    void CheckPlayerDistance() // 
    {
        if( monsterStats.attackRange < distance && distance < monsterStats.followRange)
        {
            dir = (player.position - transform.position).normalized;
        }
        else
        {
            dir = Vector2.zero;
        }
       
    }

}
