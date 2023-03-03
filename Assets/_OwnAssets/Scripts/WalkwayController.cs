using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkwayController : MonoBehaviour
{
    private float walkwaySpeedSliderValue = 1f;

    public GameObject[] walkwayInstances; // The static walkways
    public UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider continuousMoveProvider;

    public void ChangeWalkwaySpeed(float value)
    {
        walkwaySpeedSliderValue = value;

        // Change static walkways' speeds
        foreach(GameObject walkway in walkwayInstances)
        {
            walkway.GetComponentInChildren<Conveyor>().speed = walkwaySpeedSliderValue;

            ParticleController pc = walkway.GetComponentInChildren<ParticleController>(true);
            if (pc != null)
            {
                pc.speed = walkwaySpeedSliderValue * pc.speed;
                pc.lifetime = pc.lifetime / walkwaySpeedSliderValue;
                pc.emissionSpeed = walkwaySpeedSliderValue * pc.emissionSpeed;
                pc.noise = pc.noise / walkwaySpeedSliderValue;
            }
        }

        // Also change continuous movement speed
        continuousMoveProvider.moveSpeed = walkwaySpeedSliderValue;
    }
}