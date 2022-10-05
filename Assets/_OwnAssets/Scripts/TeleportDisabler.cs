using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDisabler : MonoBehaviour
{
    public StartingMode gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (gameManager.Style != StartingMode.Mode.MovingWalkway)
            return;

        if (collision.gameObject.GetComponent<Conveyor>() != null || collision.gameObject.GetComponentInChildren<Conveyor>(true) != null)
            gameManager.DisableTeleportation();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (gameManager.Style != StartingMode.Mode.MovingWalkway)
            return;

        if (collision.gameObject.GetComponent<Conveyor>() != null || collision.gameObject.GetComponentInChildren<Conveyor>(true) != null)
            gameManager.EnableTeleportation();
    }
}
