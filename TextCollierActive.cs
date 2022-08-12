using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCollierActive : MonoBehaviour
{
    public GameObject Text;
    public GameObject Text2;
    public GameObject Text3;

    private void Start()
    {
        Text.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player2")
        {
            Text.SetActive(true);
            Text2.SetActive(true);
            Text3.SetActive(true);
        }
    }
}
