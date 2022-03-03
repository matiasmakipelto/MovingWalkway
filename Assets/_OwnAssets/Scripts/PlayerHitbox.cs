using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    private Rigidbody rigidbody;
    private BoxCollider boxCollider;
    private Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        camera = transform.GetChild(0).GetChild(0);
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.center = new Vector3(camera.position.x - transform.position.x, boxCollider.center.y, camera.position.z - transform.position.z);
    }
}
