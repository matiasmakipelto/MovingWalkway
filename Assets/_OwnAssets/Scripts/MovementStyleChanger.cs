using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementStyleChanger : MonoBehaviour
{
    public GameObject player;
    public GameObject locomotionSystem;
    private TeleportationProvider teleportationProvider;
    private ContinuousMoveProviderBase continuousMoveProvider;


    public GameObject changeNotifier;
    private CanvasGroup canvasGroup;
    private GameObject continuousMovementNotifier;
    private GameObject teleportationNotifier;
    private GameObject movingWalkwayNotifier;
    private bool fadeOut;
    private bool fadeIn;
    public int notificationLength;
    private int notificationTimer;
    private float deltaAlpha = 0.02f;

    public MovementStyle movementStyle;
    public enum MovementStyle
    {
        ContinuousMovement = 0,
        Teleportation = 1,
        MovingWalkway = 2
    }

    private void Start()
    {
        teleportationProvider = locomotionSystem.GetComponent<TeleportationProvider>();
        continuousMoveProvider = locomotionSystem.GetComponent<ContinuousMoveProviderBase>();
        canvasGroup = changeNotifier.GetComponent<CanvasGroup>();
        continuousMovementNotifier = changeNotifier.transform.GetChild(0).gameObject;
        teleportationNotifier = changeNotifier.transform.GetChild(1).gameObject;
        movingWalkwayNotifier = changeNotifier.transform.GetChild(2).gameObject;
        canvasGroup.alpha = 0f;

        SetMovementStyle();
    }

    public void ChangeMovementStyle(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            switch (movementStyle)
            {
                case MovementStyle.ContinuousMovement:
                    movementStyle = MovementStyle.Teleportation;
                    break;

                case MovementStyle.Teleportation:
                    movementStyle = MovementStyle.MovingWalkway;
                    break;

                case MovementStyle.MovingWalkway:
                    movementStyle = MovementStyle.ContinuousMovement;
                    break;
            }

            SetMovementStyle();
        }
    }

    public void SetMovementStyle()
    {
        Debug.Log("Movement Style Changed");

        // Assign others false every time so that the application can be started with different values
        switch (movementStyle)
        {
            case MovementStyle.ContinuousMovement:
                continuousMoveProvider.enabled = true;
                teleportationProvider.enabled = false;
                continuousMovementNotifier.SetActive(true);
                teleportationNotifier.SetActive(false);
                movingWalkwayNotifier.SetActive(false);
                break;

            case MovementStyle.Teleportation:
                continuousMoveProvider.enabled = false;
                teleportationProvider.enabled = true;
                continuousMovementNotifier.SetActive(false);
                teleportationNotifier.SetActive(true);
                movingWalkwayNotifier.SetActive(false);
                break;

            case MovementStyle.MovingWalkway:
                continuousMoveProvider.enabled = false;
                teleportationProvider.enabled = false;
                continuousMovementNotifier.SetActive(false);
                teleportationNotifier.SetActive(false);
                movingWalkwayNotifier.SetActive(true);
                break;
        }

        canvasGroup.alpha = 0f; // In case movement style is changed before canvas disappears
        fadeIn = true;
    }

    public void FixedUpdate()
    {
        // Notification
        if (fadeIn)
        {
            canvasGroup.alpha += deltaAlpha;

            if (canvasGroup.alpha >= 1f)
            {
                fadeIn = false;
                notificationTimer = notificationLength;
            }
        }

        if (notificationTimer > 0)
        {
            notificationTimer--;
            if (notificationTimer == 0)
                fadeOut = true;
        }

        if (fadeOut)
        {
            canvasGroup.alpha -= deltaAlpha;
            if (canvasGroup.alpha <= 0f)
                fadeOut = false;
        }



    }
}

