using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D ProjectileRigid;
    [SerializeField] float speed;
    bool onMove;
    private void Start()
    {
        ProjectileRigid = GetComponent<Rigidbody2D>();
        onMove = true;
    }

    void Update()
    {
        if(onMove && ProjectileRigid)
            ProjectileRigid.position += (Vector2)(transform.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        //Command to "false" your "Active" if you currently collide with any collider other than the player. Modified since then
        if (_collision.gameObject.tag != "Player") gameObject.SetActive(false);
    }
}
