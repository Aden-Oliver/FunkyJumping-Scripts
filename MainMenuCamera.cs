using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public float speed = -10;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
