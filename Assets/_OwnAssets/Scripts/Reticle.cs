using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public GameObject shape;
    public GameObject controller;
    public GameObject walkwayPrefab;
    private GameObject walkwayInstance;
    public bool playerCentric;
    public bool manualRotation;
    public float rotationSpeed;

    void Update()
    {
        // Rotate away from player
        if (playerCentric)
            shape.transform.eulerAngles = new Vector3(0, controller.transform.eulerAngles.y, 0);

        if (manualRotation)
            shape.transform.eulerAngles = new Vector3(0, shape.transform.eulerAngles.y + rotationSpeed, 0);
    }

    public void manualRotate(Vector2 value)
    {
        if (manualRotation == false)
            return;

        shape.transform.eulerAngles = new Vector3(0, shape.transform.eulerAngles.y + value.x, 0);
    }

    // Show reticle only when button is held
    public void showReticle()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void placeWalkway()
    {
        // Make new walkway
        if (!walkwayInstance)
        {
            walkwayInstance = Instantiate(walkwayPrefab, transform.position, shape.transform.rotation);
        }

        // Reposition old walkway
        else
        {
            walkwayInstance.transform.position = transform.position;
            walkwayInstance.transform.rotation = shape.transform.rotation;
        }

        // Hide reticle
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log(gameObject);
        Debug.Log("hidden");
    }
}
