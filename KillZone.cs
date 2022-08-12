using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public FPSInput Player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player2")
        {
            Player.damage(20);
        }
    }
}
