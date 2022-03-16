using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject leftController;
    public GameObject rightController;

    private bool lineWasOn;

    public void TogglePause()
    {
        if (!pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            leftController.GetComponent<XRRayInteractor>().enabled = false;
            lineWasOn = leftController.GetComponent<LineRenderer>().enabled;
            leftController.GetComponent<LineRenderer>().enabled = false;
            leftController.GetComponent<XRInteractorLineVisual>().enabled = false;

            rightController.GetComponent<XRRayInteractor>().enabled = true;
            rightController.GetComponent<LineRenderer>().enabled = true;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            leftController.GetComponent<XRRayInteractor>().enabled = true;
            leftController.GetComponent<LineRenderer>().enabled = lineWasOn;
            leftController.GetComponent<XRInteractorLineVisual>().enabled = lineWasOn;


            rightController.GetComponent<XRRayInteractor>().enabled = false;
            rightController.GetComponent<LineRenderer>().enabled = false;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = false;
        }

    }
}
