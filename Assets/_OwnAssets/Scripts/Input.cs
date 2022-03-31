using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject reticle;
    public GameObject teleportArea;

    void OnChangeMovementSystem()
    {
        gameManager.GetComponent<MovementStyleChanger>().ChangeMovementStyle();
    }

    void OnRotateReticle(InputValue value)
    {
        if (gameManager.GetComponent<MovementStyleChanger>().movementStyle != MovementStyleChanger.MovementStyle.MovingWalkway)
            return;

        reticle.GetComponent<Reticle>().rotationSpeed = ((Vector2)value.Get()).x;
    }

    void OnPlaceWalkway(InputValue value)
    {
        if (gameManager.GetComponent<MovementStyleChanger>().movementStyle != MovementStyleChanger.MovementStyle.MovingWalkway)
            return;

        if (value.isPressed == true)
            reticle.GetComponent<Reticle>().ShowReticle();
        else
            reticle.GetComponent<Reticle>().PlaceWalkway();
    }

    void OnPause(InputValue value)
    {
        gameManager.GetComponent<Menu>().TogglePause();
    }

    void OnDebugTeleport(InputValue value)
    {
        teleportArea.GetComponent<DebugTeleport>().Teleport();
    }
}
