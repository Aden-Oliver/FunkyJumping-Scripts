using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook_New : MonoBehaviour
{
    public float sensitivity = 100;
    public Transform Player;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 75f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Player.Rotate(Vector3.up * mouseX);
    }
}