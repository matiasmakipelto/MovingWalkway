using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public GameObject customCollider;
    private Transform cam; // camera
    // Start is called before the first frame update
    void Start()
    {
        cam = transform.GetChild(0).GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        customCollider.transform.localPosition = new Vector3(cam.localPosition.x, customCollider.transform.localPosition.y, cam.localPosition.z);
    }
}
