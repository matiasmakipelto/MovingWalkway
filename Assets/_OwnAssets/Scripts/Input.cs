using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject teleportArea;

    void OnPause(InputValue value)
    {
        gameManager.GetComponent<Menu>().TogglePause();
    }

    void OnDebugTeleport(InputValue value)
    {
        teleportArea.GetComponent<DebugTeleport>().Teleport();
    }
}
