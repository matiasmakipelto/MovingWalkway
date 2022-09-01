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
    public GameObject hologramWalkway;
    public GameObject realisticNoSidesWalkway;
    public GameObject realistinWalkway;
    public GameObject windWalkway;

    public WalkwayStyle walkwayStyle;
    public enum WalkwayStyle
    {
        Realistic,
        RealisticNoSides,
        Wind,
        Hologram
    }

    private bool lineWasOn;

    public void ChangeWalkwayStyle(string style)
    {
        walkwayStyle = (WalkwayStyle)System.Enum.Parse(typeof(WalkwayStyle), style);
        //reticle.GetComponent<Reticle>().ChangeReticleInto(walkwayStyle);

        hologramWalkway.SetActive(walkwayStyle == WalkwayStyle.Hologram);
        realisticNoSidesWalkway.SetActive(walkwayStyle == WalkwayStyle.RealisticNoSides);
        realistinWalkway.SetActive(walkwayStyle == WalkwayStyle.Realistic);
        windWalkway.SetActive(walkwayStyle == WalkwayStyle.Wind);
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
