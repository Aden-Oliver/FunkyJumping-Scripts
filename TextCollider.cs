using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollider : MonoBehaviour
{
    public GameObject Text;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player2")
        {
            Text.SetActive(false);
        }
    }
}
