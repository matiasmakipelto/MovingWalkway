using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float speedMultiplier; // Used for walkways with different lengths
    public float textureSpeedMultiplier;
    public bool reverse;
    public bool angularMovement;

    private Rigidbody rb;
    private Vector3 movement;
    private float texturePosition;

    private Material walkwayMaterial;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        walkwayMaterial = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        // Scroll texture
        texturePosition = texturePosition + speed * speedMultiplier * textureSpeedMultiplier * (reverse ? -1 : 1);
        if (texturePosition > 1)
            texturePosition--;
        else if (texturePosition < 0)
            texturePosition++;
        walkwayMaterial.mainTextureOffset = new Vector2(0, texturePosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (angularMovement)
            collision.rigidbody.constraints ^= RigidbodyConstraints.FreezeRotationY; // exclusive OR (flips the bit)
    }

    private void OnCollisionStay(Collision collision)
    {
        // Straight movement
        if (!angularMovement)
        {
            movement = transform.forward * speed * speedMultiplier * (reverse ? -1 : 1);

            rb.position -= movement;
            rb.MovePosition(rb.position + movement);
        }
        // Angular movement
        else
        {
            Vector3 eulerAngleVelocity = Vector3.back * speed * speedMultiplier * (reverse ? -1 : 1);
            Vector3 eulerAngleVelocity2 = Vector3.forward * speed * speedMultiplier * (reverse ? -1 : 1);

            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity);
            Quaternion deltaRotation2 = Quaternion.Euler(eulerAngleVelocity2);

            rb.rotation = rb.rotation * deltaRotation2;
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (angularMovement)
            collision.rigidbody.constraints ^= RigidbodyConstraints.FreezeRotationY;
    }
}
