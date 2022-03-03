using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float textureSpeedMultiplier;

    private Rigidbody rigidbody;
    private Vector3 movement;
    private float texturePosition;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Scroll texture
        texturePosition = texturePosition + speed * textureSpeedMultiplier;
        //GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, texturePosition);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision");
        movement = transform.forward * speed;

        rigidbody.position -= movement;
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
