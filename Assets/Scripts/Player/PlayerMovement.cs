using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables that control the player's movement. Can only move when in the "true" state.
    public bool onMove;
    
    //Component
    PlayerStats Stats;
    Rigidbody2D PlayerRigid;
    SpriteRenderer PlayerRenderer;
    void Start()
    {
        Stats = GetComponent<PlayerStats>();
        PlayerRigid = GetComponent<Rigidbody2D>();
        PlayerRenderer = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        if (!PlayerRigid) Debug.Log("PlayerMovement.cs : Rigidbody is Null!");
        if (!PlayerRenderer) Debug.Log("PlayerMovement.cs : SpriteRenderer is Null!");
        onMove = true;
    }

    void Update()
    {
        if (onMove && PlayerRigid)
        {
            Move();
            Look();
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
            PlayerRigid.position += moveDirection * Stats.getSpeed * Time.deltaTime;
    }
    void Look()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x)
            PlayerRenderer.flipX = false;
        else
            PlayerRenderer.flipX = true;
    }
}

