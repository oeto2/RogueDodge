using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    Rigidbody2D PlayerRigid;
    bool onInteraction = false;
    InteractableObject InteractableObj;
    Canvas InteractionUI;
    //[SerializeField] string playerInteractionKeyname;
    private void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        InteractionUI = transform.Find("Canvas").GetComponent<Canvas>();
        if(InteractionUI.renderMode == RenderMode.WorldSpace) InteractionUI.worldCamera = Camera.main;
        if(InteractionUI.gameObject.activeSelf) InteractionUI.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(onInteraction && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Input the F Key");
            InteractionUI.gameObject.SetActive(false);
            InteractableObj.Interaction();
        }
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        Debug.Log("Enter the Trigger");
        if (_collision.CompareTag("Interactable"))
        {
            onInteraction = true;
            InteractionUI.gameObject.SetActive(true);
            InteractableObj = _collision.GetComponent<InteractableObject>();
        }
    }
    private void OnTriggerExit2D(Collider2D _collision)
    {
        Debug.Log("Exit the Trigger");
        if (_collision.CompareTag("Interactable"))
        {
            onInteraction = true;
            InteractionUI.gameObject.SetActive(false);
            InteractableObj = null;
        }
    }
}
