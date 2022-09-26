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
}
