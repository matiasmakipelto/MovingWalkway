using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuMover : MonoBehaviour
{
    public Transform gameCamera;
    public float distance;
    public float height;
    private Vector3 cameraForward;

    public void placeMenu()
    {
        cameraForward = gameCamera.transform.forward;
        Vector3 newPosition = gameCamera.position + cameraForward * distance;
        transform.position = new Vector3(newPosition.x, height, newPosition.z);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, gameCamera.transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void Update()
    {
        Vector3 newPosition = gameCamera.position + cameraForward * distance;
        transform.position = new Vector3(newPosition.x, height, newPosition.z);
    }
}
