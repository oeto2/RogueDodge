using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTER_STATE
{
    IDLE,
    ATTACK,
    DIE
}
public enum MONSTER_TYPE
{
    MELLE,
    RANGE,
    STATIONARY
}

public class MonsterStats : MonoBehaviour
{
    //states
    public string monsterName = "";
    public int hp;
    public float atk;
    float collisionDamage = 5;
    public float speed;
    public float followRange;
    public float attackRange;
    public float attackCoolTime;
    //public float runawayRange;

    public bool IsAttacking;

    public Transform projectileSpawner;
    public LayerMask target;
    public MONSTER_TYPE eMONSTER_TYPE;
    public MONSTER_STATE eMONSTER_STATE = MONSTER_STATE.IDLE;
    public SpriteRenderer[] spriteRendererss;

    //Range
    public GameObject projectile;

    
}
