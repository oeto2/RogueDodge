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

        //player = GameManager.Instance.player;
        OnMoveEvent += Move;
    }

    protected override void Update()
    {
        base.Update();
        CheckPlayerDistance();
    }

    private void FixedUpdate()
    {
        MoveAction();
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
        dir = (player.position - transform.position).normalized;
        //Todo
        //Todo
    }


    void CheckPlayerDistance() // 
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (Physics2D.OverlapCircle(transform.position, monsterStats.followRange, monsterStats.target))
        {
            //Todo
            //Todo
            //Todo
            
        }
    }

}
