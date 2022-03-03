using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStyleChanger : MonoBehaviour
{
    public GameObject player;
    public GameObject locomotionSystem;
    private GameObject leftHand;
    private GameObject rightHand;
    // Start is called before the first frame update
    void Start()
    {
        leftHand = player.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        rightHand = player.transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
