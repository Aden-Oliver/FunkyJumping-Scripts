using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObjective : MonoBehaviour
{
    public FPSInput Player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "DiscoBall(Clone)")
        {
            Player.objectiveScore += 1;
            Destroy(this.gameObject);
            Destroy(col.gameObject);
        }
    }
}
