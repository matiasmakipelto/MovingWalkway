using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject reticle;

    void OnChangeMovementSystem()
    {
        gameManager.GetComponent<MovementStyleChanger>().ChangeMovementStyle();
    }

    void OnRotateReticle(InputValue value)
    {
        reticle.GetComponent<Reticle>().rotationSpeed = ((Vector2)value.Get()).x;
    }

    void OnPlaceWalkway(InputValue value)
    {
        if (gameManager.GetComponent<MovementStyleChanger>().movementStyle != MovementStyleChanger.MovementStyle.MovingWalkway)
            return;

        Debug.Log("placed");
        reticle.GetComponent<Reticle>().placeWalkway();
    }
}
