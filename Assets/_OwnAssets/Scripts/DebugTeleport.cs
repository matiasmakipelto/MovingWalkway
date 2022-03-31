using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTeleport : MonoBehaviour
{
    public GameObject player;

    public void Teleport()
    {
        if (!this.gameObject.activeInHierarchy)
            return;

        player.transform.position = transform.position;
    }
}
