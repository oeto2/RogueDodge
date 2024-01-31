using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour
{
    Vector2 targetPosition; //타겟 포지션을 받으
    Vector2 dir;
    bool IsOnTarget;
    bool hitTarget;
    Rigidbody2D _rigidbody;
    CircleCollider2D _collider;


    public int damage;
    public float projectileSpeed;
    public SpriteRenderer mainSprite;
    public GameObject defaultEffect;
    public GameObject crashEffect;

    float zAngle;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private void Update()
    {
        if (!hitTarget)
        {
        _rigidbody.position += dir * Time.deltaTime * projectileSpeed;
        }
        else
        {
            transform.position = GameManager.Instance.PlayerTransform.position;
        }


        if(IsOnTarget && Vector2.Distance(targetPosition,(Vector2)transform.position) < 0.1f)
        {
           
            MainEffectOff();
            dir = Vector2.zero;
            GameObject _crashEffect = Instantiate(crashEffect, targetPosition, Quaternion.identity);
            _crashEffect.transform.Rotate(Vector3.forward, 90);
            Destroy(_crashEffect, 1f);
            Destroy(gameObject, 2f);
        }
    }

  

    public void SetTargetPosition(Vector2 target,bool onTarget)
    {
        targetPosition = target;
        dir = (target - (Vector2)transform.position).normalized;
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.Rotate(Vector3.forward, zAngle);
        IsOnTarget = onTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            hitTarget = true;
            MainEffectOff();
            GameObject _crashEffect = Instantiate(crashEffect, targetPosition, Quaternion.identity);
            _crashEffect.transform.Rotate(Vector3.forward, zAngle);
            Destroy(_crashEffect, 1f);
            collision.gameObject.GetComponent<PlayerStats>().PlayerDamaged(damage);
            Destroy(gameObject, 2f);

        }
    }

    void MainEffectOff()
    {
        defaultEffect.SetActive(false);
        mainSprite.enabled = false;
        _collider.enabled = false;
    }

}
