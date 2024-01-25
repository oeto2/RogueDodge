using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool onAttack;
    IEnumerator AttackCourt = null;

    //Component
    PlayerStats Stats;
    [SerializeField] GameObject PlayerAttack_Projectile;
    [SerializeField] float atkCoolTime;
    //PoolingList
    List<GameObject> PlayerObjectList;

    void Start()
    {
        Stats = GetComponent<PlayerStats>();
        PlayerObjectList = new List<GameObject>();
        if(!Stats) Debug.Log("PlayerAttack.cs : Stats is Null!");
        onAttack = true;
    }

    void Update()
    {
        if (onAttack && PlayerAttack_Projectile)
        {
            Attack();
        }
    }
    void Attack()
    {
        float inputAttack = Input.GetAxisRaw("Fire1");

        if (inputAttack > 0 && AttackCourt == null)
        {
            AttackCourt = Attack_Coroutine();
            StartCoroutine(AttackCourt);
        }
    }

    IEnumerator Attack_Coroutine()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //How to create an attack projectile, not an attack. Generation is also created using object pooling.
        ObjectPooling(PlayerAttack_Projectile, mousePos);

        yield return new WaitForSeconds(atkCoolTime);

        AttackCourt = null;
    }

    void ObjectPooling(GameObject _obj, Vector2 _mousePos)
    {
        //No tag or layer value to distinguish objects at the moment. Need to add more afterwards.
        GameObject obj = PlayerObjectList.Find(item => item.gameObject.tag == _obj.tag && !item.activeSelf);
        
        //Code to move objects in the direction of the mouse. Not a fully aware and written code yet. Need to learn.
        float attackDirection = Mathf.Atan2(_mousePos.y - transform.position.y, _mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion objAngle = Quaternion.AngleAxis(attackDirection - 90f, Vector3.forward);
        if (obj)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = objAngle;
            obj.SetActive(true);
        }
        else
        {
            obj = _obj;
            PlayerObjectList.Add(Instantiate(obj, transform.position, objAngle));
        }

        //Projectile
        Projectile p = obj.GetComponent<Projectile>();
        if (p)
        {
            p.atk = Stats.getAtk;
        }
    }
}
