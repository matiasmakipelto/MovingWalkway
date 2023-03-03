using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartingMode : MonoBehaviour
{
    public Mode Style;
    public enum Mode
    {
        MovingWalkway,
        ControllerMovement,
        ModelComparison
    }

    public GameObject[] courseWalkways;
    public GameObject locomotionSystem;
    public GameObject[] speedSetWalkways;
    public GameObject changingWalkway;
    public GameObject[] uiSpeedGroup;
    public GameObject[] uiModelGroup;
    public WalkwayController walkwayController;
    public GameObject leftController;

    void Start()
    {
        walkwayController.ChangeWalkwaySpeed(SliderValueSaver.loadValue());
        switch(Style)
        {
            case Mode.MovingWalkway:
                foreach(GameObject uiElement in uiModelGroup)
                    uiElement.SetActive(false);

                break;

            case Mode.ControllerMovement:
                foreach (GameObject uiElement in uiModelGroup)
                    uiElement.SetActive(false);

                locomotionSystem.GetComponent<ContinuousMoveProviderBase>().enabled = true;
                DisableTeleportation();

                foreach (GameObject walkway in courseWalkways)
                    walkway.GetComponentInChildren<Conveyor>().enabled = false;

                break;

            case Mode.ModelComparison:
                foreach (GameObject uiElement in uiSpeedGroup)
                    uiElement.SetActive(false);

                foreach (GameObject walkway in courseWalkways)
                    walkway.GetComponentInChildren<Conveyor>().enabled = false;

                foreach (GameObject walkway in speedSetWalkways)
                    walkway.SetActive(false);

                changingWalkway.SetActive(true);

                break;
        }
            
    }

    public void DisableTeleportation()
    {
        locomotionSystem.GetComponent<TeleportationProvider>().enabled = false;
        leftController.GetComponent<XRRayInteractor>().enabled = false;
        leftController.GetComponent<LineRenderer>().enabled = false;
        leftController.GetComponent<XRInteractorLineVisual>().enabled = false;
    }

    public void EnableTeleportation()
    {
        locomotionSystem.GetComponent<TeleportationProvider>().enabled = true;
        leftController.GetComponent<XRRayInteractor>().enabled = true;
        leftController.GetComponent<LineRenderer>().enabled = true;
        leftController.GetComponent<XRInteractorLineVisual>().enabled = true;
    }
}
