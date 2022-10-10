using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDisabler : MonoBehaviour
{
    public StartingMode gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.Style == StartingMode.Mode.ControllerMovement)
            return;

        if (other.transform.parent.parent.name == "Player")
            gameManager.DisableTeleportation();
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameManager.Style == StartingMode.Mode.ControllerMovement)
            return;

        if (other.transform.parent.parent.name == "Player")
            gameManager.EnableTeleportation();
    }
}
