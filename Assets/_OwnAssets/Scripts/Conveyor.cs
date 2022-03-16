using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float textureSpeedMultiplier;

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
        texturePosition = texturePosition + speed * textureSpeedMultiplier;
        if (texturePosition > 1)
            texturePosition--;
        walkwayMaterial.mainTextureOffset = new Vector2(0, texturePosition);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision");
        movement = transform.forward * speed;

        rb.position -= movement;
        rb.MovePosition(rb.position + movement);
    }
}
