using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    MonsterController monsterController;
    Animator animator;

    static readonly int IsAttack = Animator.StringToHash("attack");


    private void Awake()
    {
        animator = GetComponent<Animator>();
        monsterController = GetComponent<MonsterController>();
        monsterController.OnAttackEvent += AnimationAttack;
    }



    void AnimationAttack()
    {
        animator.SetTrigger(IsAttack);
    }
    
}
