using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    // Middle finger
    public void RightGrip(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Right grip: " + context.phase);
    }

    // Middle finger
    public void LeftGrip(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Left grip: " + context.phase);
    }

    // Index finger
    public void RightTrigger(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Right trigger: " + context.phase);
    }

    // Index finger
    public void LeftTrigger(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Left trigger: " + context.phase);
    }

    public void A(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("A: " + context.phase);
    }

    public void B(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("B: " + context.phase);
    }

    public void X(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("X: " + context.phase);
    }

    public void Y(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Y: " + context.phase);
    }

    public void RightMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Right menu: " + context.phase);
    }

    public void LeftMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Right menu: " + context.phase);
    }

    public void RightJoystickClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Right joystick: " + context.phase);
    }

    public void LeftJoystickClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            Debug.Log("Left joystick: " + context.phase);
    }
}
