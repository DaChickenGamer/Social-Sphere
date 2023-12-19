using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] public bool isInteracting;
    
    public void OnInteract(InputAction.CallbackContext ctxt)
    {
        if (ctxt.started)
        {
            isInteracting = true;
        }
        if (ctxt.canceled)
        {
            isInteracting = false;
        }
    }
    
    public bool GetIsInteracting()
    {
        return isInteracting;
    }
}
