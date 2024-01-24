using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallOnMoveEvent(Vector2 dir)
    {
        OnMoveEvent?.Invoke(dir);
    }
    public void CallOnLookEvent(Vector2 dir)
    {
        OnLookEvent?.Invoke(dir);
    }

}
