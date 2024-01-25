using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    MonsterController monsterController;
    Rigidbody2D _rigidbody;
    Vector2 dir = Vector2.zero;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        monsterController.OnMoveEvent += Move;
    }

    void Update()
    {
        
        CheckPlayerDistance();
    }

    private void FixedUpdate()
    {
        if(monsterController.monsterStats.eMONSTER_STATE != MONSTER_STATE.ATTACK)
        {
            MoveAction();
        }
    }

    void Move(Vector2 _dir)
    {
        _rigidbody.position += _dir * Time.deltaTime * monsterController.monsterStats.speed;
        for (int i = 0; i < monsterController.monsterStats.spriteRendererss.Length; i++)
        {
            monsterController.monsterStats.spriteRendererss[i].flipX = _dir.x > 0;
        }
    }



    void MoveAction()
    {
        monsterController.CallOnMoveEvent(dir);
        //Todo
        //Todo
    }


    void CheckPlayerDistance() // 
    {
        if(monsterController.monsterStats.attackRange < monsterController.distance && monsterController.distance < monsterController.monsterStats.followRange)
        {
            dir = (monsterController.player.position - transform.position).normalized;
        }
        else
        {
            dir = Vector2.zero;
        }
       
    }

}
