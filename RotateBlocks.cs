using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlocks : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.Rotate(.5f, 0f, 0f);
    }
}
