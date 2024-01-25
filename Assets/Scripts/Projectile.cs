using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D ProjectileRigid;
    [SerializeField] float speed;
    [SerializeField] float range;
    bool onMove;
    Vector2 StartPos;
    private void Start()
    {
        ProjectileRigid = GetComponent<Rigidbody2D>();
        onMove = true;
    }

    private void OnEnable()
    {
        StartPos = transform.position;
    }

    void Update()
    {
        if(onMove && ProjectileRigid)
            ProjectileRigid.position += (Vector2)(transform.up * speed * Time.deltaTime);
        if (transform.position.magnitude > StartPos.magnitude + range) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        //Command to "false" your "Active" if you currently collide with any collider other than the player. Modified since then
        if (_collision.gameObject.tag != "Player" && _collision.gameObject.tag != "Projectile") gameObject.SetActive(false);
    }
}
