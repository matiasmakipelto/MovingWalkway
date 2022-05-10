using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public GameObject shape;
    public GameObject controller;
    public GameObject manager;

    public GameObject realisticWalkwayPrefab;
    public GameObject realisticWalkwayNoSidesPrefab;
    public GameObject windWalkwayPrefab;
    public GameObject hologramWalkwayPrefab;

    private GameObject currentReticle; // The reticle corresponding to current style
    private GameObject currentReticlePrefab;

    private GameObject walkwayInstance;
    public bool playerCentric;
    public bool manualRotation;
    public float rotationSpeed;

    private float walkwaySpeedSliderValue = 1f;
    public float windSpeed;
    public float windLifetime;
    public float windEmissionSpeed;
    public float windNoise;

    public GameObject[] walkwayInstances; // The static walkways
    public UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider continuousMoveProvider;

    private void Start()
    {
        currentReticle = shape.transform.GetChild(0).gameObject;
        currentReticlePrefab = realisticWalkwayPrefab;
    }

    void Update()
    {
        // Rotate away from player
        if (playerCentric)
            shape.transform.eulerAngles = new Vector3(0, controller.transform.eulerAngles.y, 0);

        if (manualRotation)
            shape.transform.eulerAngles = new Vector3(0, shape.transform.eulerAngles.y + rotationSpeed, 0);
    }

    public void ChangeReticleInto(Menu.WalkwayStyle style)
    {
        // Disable all reticle styles
        foreach (Transform child in shape.transform)
            child.gameObject.SetActive(false);

        // Enable correct reticle style
        switch (style)
        {
            case Menu.WalkwayStyle.Realistic:
                currentReticle = shape.transform.GetChild(0).gameObject;
                currentReticlePrefab = realisticWalkwayPrefab;
                break;

            case Menu.WalkwayStyle.RealisticNoSides:
                currentReticle = shape.transform.GetChild(1).gameObject;
                currentReticlePrefab = realisticWalkwayNoSidesPrefab;
                break;

            case Menu.WalkwayStyle.Wind:
                currentReticle = shape.transform.GetChild(2).gameObject;
                currentReticlePrefab = windWalkwayPrefab;
                break;

            case Menu.WalkwayStyle.Hologram:
                currentReticle = shape.transform.GetChild(3).gameObject;
                currentReticlePrefab = hologramWalkwayPrefab;
                break;
        }
    }

    public void DisableReticle()
    {
        currentReticle.SetActive(false);
    }

    public void ManualRotate(Vector2 value)
    {
        if (manualRotation == false)
            return;

        shape.transform.eulerAngles = new Vector3(0, shape.transform.eulerAngles.y + value.x, 0);
    }

    // Show reticle only when button is held
    public void ShowReticle()
    {
        currentReticle.SetActive(true);
    }

    public void PlaceWalkway()
    {
        // Destroy old walkway
        if (walkwayInstance)
            Destroy(walkwayInstance);

        // Make new walkway
        walkwayInstance = Instantiate(currentReticlePrefab, transform.position, shape.transform.rotation);

        // Change speed of new instance
        walkwayInstance.GetComponentInChildren<Conveyor>().speed = walkwaySpeedSliderValue;
        if (walkwayInstance.GetComponent<ParticleController>())
        {
            ParticleController pc = walkwayInstance.GetComponent<ParticleController>();
            pc.speed = walkwaySpeedSliderValue * windSpeed;
            pc.lifetime = windLifetime / walkwaySpeedSliderValue;
            pc.emissionSpeed = walkwaySpeedSliderValue * windEmissionSpeed;
            pc.noise = windNoise / walkwaySpeedSliderValue;
        }

        // Hide reticle
        currentReticle.SetActive(false);
    }

    public void ChangeWalkwaySpeed(float value)
    {
        walkwaySpeedSliderValue = value;

        // Change existing instance's speed
        if (walkwayInstance)
        {
            walkwayInstance.GetComponentInChildren<Conveyor>().speed = walkwaySpeedSliderValue;

            // Change wind animation speed of existing instance
            if (manager.GetComponent<Menu>().walkwayStyle == Menu.WalkwayStyle.Wind)
            {
                ParticleController pc = walkwayInstance.GetComponentInChildren<ParticleController>();
                pc.speed = walkwaySpeedSliderValue * windSpeed;
                pc.lifetime = windLifetime / walkwaySpeedSliderValue;
                pc.emissionSpeed = walkwaySpeedSliderValue * windEmissionSpeed;
                pc.noise = windNoise / walkwaySpeedSliderValue;
            }
        }

        // Change static walkways' speeds
        foreach(GameObject walkway in walkwayInstances)
        {
            walkway.GetComponentInChildren<Conveyor>().speed = walkwaySpeedSliderValue;
        }

        // Change reticles' speeds
        Conveyor[] walkwayReticles;
        walkwayReticles = transform.GetComponentsInChildren<Conveyor>(true);
        foreach (Conveyor conveyor in walkwayReticles)
        {
            conveyor.speed = walkwaySpeedSliderValue;
        }

        // Change wind animation speed of reticle
        ParticleController pc2 = transform.GetComponentInChildren<ParticleController>(true);
        pc2.speed = walkwaySpeedSliderValue  * windSpeed;
        pc2.lifetime = windLifetime / walkwaySpeedSliderValue;
        pc2.emissionSpeed = walkwaySpeedSliderValue * windEmissionSpeed;
        pc2.noise = windNoise / walkwaySpeedSliderValue;

        // Also change continuous movement speed
        continuousMoveProvider.moveSpeed = walkwaySpeedSliderValue;
    }
}