using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int hp;
    float speed;
    string name;
    float atk;
    //Variables that control the player's movement. Can only move when in the "true" state.
    bool onMove;
    Rigidbody2D PlayerRigid;

    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        if (!PlayerRigid) Debug.Log("Player.cs : Rigidbody is Null!");
        onMove = true;
    }

    
    void Update()
    {
        if(onMove && PlayerRigid)
        {
            Move();
        }
    }

    void Move()
    {
        //If the arrow key operation and WASD operation come in, the value of -1,1 comes in. If there is no input, 0
        float inputX = Input.GetAxisRaw("Horizontal");//Left, Right
        float inputY = Input.GetAxisRaw("Vertical");//Up, Down
        //A variable that determines the direction when the operation is performed. In the case of a diagonal, the vector value is larger than if it is directed only in one direction, so "normalized" is used to equalize the vector value.
        Vector3 moveDirection = new Vector3(inputX, inputY, 0).normalized;
        //If the magnitude of the direction vector is greater than zero
        if (moveDirection.magnitude > 0)
            PlayerRigid.AddForce(moveDirection * speed);
    }
}
