using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;
    private Transform cam; // camera
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        cam = transform.GetChild(0).GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.center = new Vector3(cam.localPosition.x, boxCollider.center.y, cam.localPosition.z);
        sphereCollider.center = new Vector3(cam.localPosition.x, sphereCollider.center.y, cam.localPosition.z);
    }
}
