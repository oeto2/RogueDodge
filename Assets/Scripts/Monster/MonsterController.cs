using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<Vector2> OnAttackEvent;



    public void CallOnMoveEvent(Vector2 _dir)
    {
        OnMoveEvent?.Invoke(_dir);
    }
    public void CallOnLookEvent(Vector2 _dir)
    {
        OnLookEvent?.Invoke(_dir);
    }
    public void CallOnAttackEvent(Vector2 _dir)
    {
        OnAttackEvent?.Invoke(_dir);
    }
}
