using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    Vector2 dir = Vector2.zero;
    Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        _rigidbody.position += dir;
    }


    public void SetDir(Vector2 _dir)
    {
        dir = _dir;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //todo
        //todo//todo
        Destroy(gameObject);
    }
}
