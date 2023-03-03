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
    public bool onWalkway;

    public WalkwayStyle walkwayStyle;
    public enum WalkwayStyle
    {
        Realistic,
        RealisticNoSides,
        Wind,
        Hologram
    }

    private StartingMode.Mode startingStyle;

    private void Start()
    {
        startingStyle = GetComponent<StartingMode>().Style;
    }

    public void ChangeWalkwayStyle(string style)
    {
        walkwayStyle = (WalkwayStyle)System.Enum.Parse(typeof(WalkwayStyle), style);

        hologramWalkway.SetActive(walkwayStyle == WalkwayStyle.Hologram);
        realisticNoSidesWalkway.SetActive(walkwayStyle == WalkwayStyle.RealisticNoSides);
        realistinWalkway.SetActive(walkwayStyle == WalkwayStyle.Realistic);
        windWalkway.SetActive(walkwayStyle == WalkwayStyle.Wind);
    }

    public void TogglePause()
    {
        if (!pauseMenu.activeSelf)
        {
            pauseMenu.GetComponent<PauseMenuMover>().placeMenu();
            pauseMenu.SetActive(true);

            if (startingStyle != StartingMode.Mode.ControllerMovement)
                GetComponent<StartingMode>().DisableTeleportation();

            rightController.GetComponent<XRRayInteractor>().enabled = true;
            rightController.GetComponent<LineRenderer>().enabled = true;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = true;
        }
        else
        {
            pauseMenu.SetActive(false);


            if (startingStyle != StartingMode.Mode.ControllerMovement)
                if (!onWalkway)
                    GetComponent<StartingMode>().EnableTeleportation();


            rightController.GetComponent<XRRayInteractor>().enabled = false;
            rightController.GetComponent<LineRenderer>().enabled = false;
            rightController.GetComponent<XRInteractorLineVisual>().enabled = false;
        }

    }
}
