using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapDirection : MonoBehaviour
{
    public Transform transf;

    public void SwapDirectionFunction()
    {
        transf.Rotate(0, 180, 0);
    }
}
