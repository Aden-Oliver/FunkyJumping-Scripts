using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInactive : MonoBehaviour
{
    public FPSInput Player;
    public GameObject Text;

    void Update()
    {
        if (Player.objectiveScore >= 3)
        {
            Text.SetActive(false);
        }
    }
}
