using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    string name = "";

    PlayerAttack AttackComponent;
    PlayerMovement MoveComponent;
    [SerializeField] int maxHp = 100;
    [SerializeField] int hp = 0;
    [SerializeField] float speed;
    public float getSpeed{ get { return speed; } }
    [SerializeField] float atk = 10;
    public float getAtk { get { return atk; } }
    public bool isDead { get { return hp <= 0; } }

    private void Start()
    {
        hp = maxHp;
        AttackComponent = GetComponent<PlayerAttack>();
        MoveComponent = GetComponent<PlayerMovement>();
        if (!AttackComponent) Debug.Log("PlayerStats.cs : AttackComponent is Null!");
        if (!MoveComponent) Debug.Log("PlayerStats.cs : MoveComponent is Null!");
    }

    public void PlayerDamaged(int _damage)
    {
        hp -= _damage;
        if (isDead) PlayerDead();
    }
    public void PlayerDead()
    {
        AttackComponent.onAttack = false;
        MoveComponent.onMove = false;
        Debug.Log("Player is Dead");
    }
}
