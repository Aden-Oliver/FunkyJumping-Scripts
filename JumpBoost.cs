using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public FPSInput Player;
    public float jump = 0;

    IEnumerator Wait()
    {
        Player.jumpHeight = 20;
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(10f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player2")
        {
            Invoke("setJumpHeight", 0f);
            Invoke("backToNormal", 10f);
        }
    }

    public void setJumpHeight()
    {
        Player.jumpUp(jump);
        this.gameObject.SetActive(false);
    }

    public void backToNormal()
    {
        Player.jumpBackToNormal();
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        transform.Rotate(0, .05f, 0);
    }
}
