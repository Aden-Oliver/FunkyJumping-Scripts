using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public GameObject text;
    public FPSInput player;
    public Animator animator;
    public bool objectiveComplete = false;

    void Start()
    {
        text.SetActive(false);
    }


    void Update()
    {
        animator.SetBool("objectiveComplete", objectiveComplete);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "DiscoBall(Clone)" && objectiveComplete == false)
        {
            objectiveComplete = true;
            text.SetActive(true);
            player.objectiveScore += 1;
        }
    }
}
