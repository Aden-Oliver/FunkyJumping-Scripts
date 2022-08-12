using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Rotate(0, .5f, 0);
    }
}
