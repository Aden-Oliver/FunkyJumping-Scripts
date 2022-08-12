using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    public bool collision = false;
    public MeshRenderer render;
    public MeshRenderer render2;
    public FPSInput player;
    public AudioSource audio;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player2")
        {
            collision = true;
            player.heal(50);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, .05f, 0);
    }
}
