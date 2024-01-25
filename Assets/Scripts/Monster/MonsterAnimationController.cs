using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    MonsterController monsterController;
    Animator animator;

    static readonly int IsAttack = Animator.StringToHash("attack");
    static readonly int IsMoving = Animator.StringToHash("isMoving");
    static readonly int IsDeath = Animator.StringToHash("death");


    private void Awake()
    {
        animator = GetComponent<Animator>();
        monsterController = GetComponent<MonsterController>();
        monsterController.OnAttackEvent += AnimationAttack;
        monsterController.OnDeathEvent += AnimationDeath;
        monsterController.OnMoveEvent += AnimationMoving;

    }



    void AnimationAttack()
    {
        animator.SetTrigger(IsAttack);
    }

    void AnimationDeath()
    {
        animator.SetBool(IsDeath,true);
    }

    void AnimationMoving(Vector2 dir)
    {
        if(dir != Vector2.zero)
        {
            animator.SetBool(IsMoving,true);
        }
        else
        {
            animator.SetBool(IsMoving, false);
        }
    }
}
