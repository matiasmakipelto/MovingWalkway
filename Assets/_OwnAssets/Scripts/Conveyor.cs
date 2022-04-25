using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;
    public float textureSpeedMultiplier;
    public bool reverse;

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
        texturePosition = texturePosition + speed * textureSpeedMultiplier * (reverse ? -1 : 1);
        if (texturePosition > 1)
            texturePosition--;
        else if (texturePosition < 0)
            texturePosition++;
        walkwayMaterial.mainTextureOffset = new Vector2(0, texturePosition);
    }

    private void OnCollisionStay(Collision collision)
    {
        movement = transform.forward * speed * (reverse ? -1 : 1);

        rb.position -= movement;
        rb.MovePosition(rb.position + movement);
    }
}
