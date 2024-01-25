using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int hp;
    [SerializeField] float speed;
    string name;
    float atk;
    float atkTime;
    [SerializeField] float atkCoolTime;
    //Variables that control the player's movement. Can only move when in the "true" state.
    bool onMove;
    bool onAttack;
    Rigidbody2D PlayerRigid;
    SpriteRenderer PlayerRenderer;
    [SerializeField] GameObject PlayerAttack_Projectile;
    List<GameObject> PlayerObjectList;
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        PlayerRenderer = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        if (!PlayerRigid) Debug.Log("Player.cs : Rigidbody is Null!");
        PlayerObjectList = new List<GameObject>();
        onMove = true;
        onAttack = true;
        atkTime = atkCoolTime;
    }

    void Update()
    {
        if(onMove && PlayerRigid)
        {
            Move();
        }
        if(onAttack && PlayerAttack_Projectile)
        {
            Attack();
        }
    }

    void Move()
    {
        //If the arrow key operation and WASD operation come in, the value of -1,1 comes in. If there is no input, 0
        float inputX = Input.GetAxisRaw("Horizontal");//Left, Right
        float inputY = Input.GetAxisRaw("Vertical");//Up, Down
        //A variable that determines the direction when the operation is performed. In the case of a diagonal, the vector value is larger than if it is directed only in one direction, so "normalized" is used to equalize the vector value.
        Vector2 moveDirection = ((Vector2.right * inputX) + (Vector2.up * inputY)).normalized;
        //If the magnitude of the direction vector is greater than zero
        if (moveDirection.magnitude > 0)
              PlayerRigid.position += moveDirection * speed * Time.deltaTime;
        
    }
    void Attack()
    {
        atkTime += Time.deltaTime;
        float inputAttack = Input.GetAxisRaw("Fire1");
        
        if(inputAttack > 0 && atkTime >= atkCoolTime)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //How to create an attack projectile, not an attack. Generation is also created using object pooling.
            ObjectPooling(PlayerAttack_Projectile, mousePos);
            atkTime = 0;
        }
    }

    void ObjectPooling(GameObject _obj, Vector2 _mousePos)
    {
        //No tag or layer value to distinguish objects at the moment. Need to add more afterwards.
        GameObject obj = PlayerObjectList.Find(item => item.gameObject == _obj && !item.activeSelf);
        if (obj)
        {
            obj.transform.position = transform.position;
            obj.SetActive(true);
        }
        else
        {
            //Code to move objects in the direction of the mouse. Not a fully aware and written code yet. Need to learn.
            float attackDirection = Mathf.Atan2(_mousePos.y - transform.position.y, _mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            PlayerObjectList.Add(Instantiate(_obj, transform.position, Quaternion.AngleAxis(attackDirection - 90f, Vector3.forward)));
        }
    }
}
