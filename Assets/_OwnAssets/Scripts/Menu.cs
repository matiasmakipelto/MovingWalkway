using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject reticle;
    public GameObject leftController;
    public GameObject rightController;

    public WalkwayStyle walkwayStyle;
    public enum WalkwayStyle
    {
        Realistic = 0,
        RealisticNoSides = 1,
        Wind = 2
    }

    private bool lineWasOn;

    public void ChangeWalkwayStyle(string style)
    {
        walkwayStyle = (WalkwayStyle)System.Enum.Parse(typeof(WalkwayStyle), style);
        reticle.GetComponent<Reticle>().ChangeReticleInto(walkwayStyle);
    }

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
