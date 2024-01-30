using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatMoveObject : MonoBehaviour
{
   [SerializeField] private GameObject TargetObject;
   [SerializeField] private Transform StartPos;
   [SerializeField] private Transform EndPos;

    [SerializeField] [Range(1f, 5f)] private float moveSpeed = 1f;

    private void Update() => MoveStart();

    public void MoveStart()
    {
        if(TargetObject.transform.position.x < EndPos.position.x)
        {
            TargetObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        else
        {
            TargetObject.transform.position = StartPos.position;
        }
    }
}
