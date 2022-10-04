using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuMover : MonoBehaviour
{
    public Transform gameCamera;
    public float distance;
    public float height;

    public void placeMenu()
    {
        Vector3 newPosition = gameCamera.position + gameCamera.transform.forward * distance;
        transform.position = new Vector3(newPosition.x, height, newPosition.z);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, gameCamera.transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
