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

    private GameObject currentReticle; // The reticle corresponding to current style
    private GameObject currentReticlePrefab;

    private GameObject walkwayInstance;
    public bool playerCentric;
    public bool manualRotation;
    public float rotationSpeed;

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

        // Hide reticle
        currentReticle.SetActive(false);
    }
}
