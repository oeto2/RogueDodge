using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public event Action InteractionEvent;

    public void Interaction()
    {
        InteractionEvent?.Invoke();
    }
}
