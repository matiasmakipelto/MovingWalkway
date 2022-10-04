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
    public Reticle reticle;
    public GameObject leftController;

    void Start()
    {
        reticle.ChangeWalkwaySpeed(SliderValueSaver.loadValue());
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

                DisableTeleportation();

                foreach (GameObject walkway in courseWalkways)
                    walkway.GetComponentInChildren<Conveyor>().enabled = false;

                foreach (GameObject walkway in speedSetWalkways)
                    walkway.SetActive(false);

                changingWalkway.SetActive(true);

                break;
        }
            
    }

    private void DisableTeleportation()
    {
        locomotionSystem.GetComponent<TeleportationProvider>().enabled = false;
        leftController.GetComponent<XRRayInteractor>().enabled = false;
        leftController.GetComponent<LineRenderer>().enabled = false;
        leftController.GetComponent<XRInteractorLineVisual>().enabled = false;
    }
}
