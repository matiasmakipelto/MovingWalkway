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
    public GameObject leftHandController;
    public GameObject rightHandController;
    public GameObject reticle;


    public GameObject changeNotifier;
    private CanvasGroup canvasGroup;
    public GameObject continuousMovementNotifier;
    public GameObject teleportationNotifier;
    public GameObject movingWalkwayNotifier;
    public GameObject noneNotifier;
    private bool fadeOut;
    private bool fadeIn;
    public float notificationLength;
    public float fadeLength;
    private float notificationTimer;

    public MovementStyle movementStyle;
    public enum MovementStyle
    {
        ContinuousMovement,
        None
        //Teleportation,
        //MovingWalkway
    }

    private void Start()
    {
        teleportationProvider = locomotionSystem.GetComponent<TeleportationProvider>();
        continuousMoveProvider = locomotionSystem.GetComponent<ContinuousMoveProviderBase>();
        canvasGroup = changeNotifier.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;

        SetMovementStyle();
    }

    public void ChangeMovementStyle()
    {
        switch (movementStyle)
        {
            case MovementStyle.ContinuousMovement:
                movementStyle = MovementStyle.None;
                break;
            case MovementStyle.None:
                movementStyle = MovementStyle.ContinuousMovement;
                break;

            //case MovementStyle.ContinuousMovement:
            //    movementStyle = MovementStyle.Teleportation;
            //    break;
            //
            //case MovementStyle.Teleportation:
            //    movementStyle = MovementStyle.MovingWalkway;
            //    break;
            //
            //case MovementStyle.MovingWalkway:
            //    movementStyle = MovementStyle.ContinuousMovement;
            //    break;
        }

        SetMovementStyle();
    }

    public void SetMovementStyle()
    {
        Debug.Log("Movement Style: " + movementStyle);




        // Notify
        switch (movementStyle)
        {
            // Assign others false every time so that the application can be started with different values
            case MovementStyle.ContinuousMovement:
                // Disable input actions so that teleportations will not get queued
                leftHandController.GetComponent<XRBaseController>().enableInputActions = false;
                continuousMoveProvider.enabled = true;
                teleportationProvider.enabled = false;
                continuousMovementNotifier.SetActive(true);
                noneNotifier.SetActive(false);
                break;

            case MovementStyle.None:
                leftHandController.GetComponent<XRBaseController>().enableInputActions = false;
                continuousMoveProvider.enabled = false;
                teleportationProvider.enabled = false;
                continuousMovementNotifier.SetActive(false);
                noneNotifier.SetActive(true);
                break;


            //case MovementStyle.Teleportation:
            //    leftHandController.GetComponent<XRBaseController>().enableInputActions = true;
            //    continuousMoveProvider.enabled = false;
            //    teleportationProvider.enabled = true;
            //    continuousMovementNotifier.SetActive(false);
            //    teleportationNotifier.SetActive(true);
            //    movingWalkwayNotifier.SetActive(false);
            //    break;
            //
            //case MovementStyle.MovingWalkway:
            //    leftHandController.GetComponent<XRBaseController>().enableInputActions = true;
            //    continuousMoveProvider.enabled = false;
            //    teleportationProvider.enabled = false;
            //    continuousMovementNotifier.SetActive(false);
            //    teleportationNotifier.SetActive(false);
            //    movingWalkwayNotifier.SetActive(true);
            //    break;
        }

        canvasGroup.alpha = 0f; // In case movement style is changed before canvas disappears
        fadeIn = true;
        fadeOut = false;
        notificationTimer = 0f;




        // Change line visual
        var leftHandLine = leftHandController.GetComponent<XRInteractorLineVisual>();
        //var rightHandLine = rightHandController.GetComponent<XRInteractorLineVisual>();
        switch (movementStyle)
        {
            case MovementStyle.ContinuousMovement:
                leftHandLine.enabled = false;
                break;

            case MovementStyle.None:
                leftHandLine.enabled = false;
                break;
                
            //case MovementStyle.ContinuousMovement:
            //    leftHandLine.enabled = false;
            //    reticle.GetComponent<Reticle>().DisableReticle();
            //    break;
            //case MovementStyle.Teleportation:
            //    leftHandLine.enabled = true;
            //    break;
            //
            //case MovementStyle.MovingWalkway:
            //    leftHandLine.enabled = true;
            //    break;
        }
    }

    public void Update()
    {
        // Notification
        if (fadeIn)
        {
            canvasGroup.alpha += Time.deltaTime / fadeLength;

            if (canvasGroup.alpha >= 1f)
            {
                fadeIn = false;
                notificationTimer = notificationLength;
            }
        }

        if (notificationTimer > 0f)
        {
            notificationTimer -= Time.deltaTime;
            if (notificationTimer <= 0f)
                fadeOut = true;
        }

        if (fadeOut)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeLength;
            if (canvasGroup.alpha <= 0f)
                fadeOut = false;
        }
    }
}

