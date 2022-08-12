using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public FPSInput Player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player2")
        {
            Debug.Log("Collision Detected");
            Invoke("setSpeed", 0f);
            Invoke("backToNormal", 10f);
        }
    }

    public void setSpeed()
    {
        Debug.Log("setSpeed");
        Player.speedUp();
        this.gameObject.SetActive(false);
    }

    public void backToNormal()
    {
        Debug.Log("backToNormal");
        Player.speedBackToNormal();
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        transform.Rotate(.05f, 0, 0);
    }
}
