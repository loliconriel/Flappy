using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Input_Controller : MonoBehaviour
{
    public event EventHandler Jump;
    public PlayerInput playerInput;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        foreach (var item in playerInput.actions.actionMaps)
        {
            item.Disable();
        }
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            playerInput.SwitchCurrentActionMap("Mobile");
        }
        else
        {
            playerInput.SwitchCurrentActionMap("Keyboard");
        }
    }
    
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            Jump?.Invoke(this, EventArgs.Empty);
        }
    }
}
