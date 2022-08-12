using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowScript : MonoBehaviour
{
    public float throwForce = 1000;
    public GameObject DiscoBall;
    public AudioSource throwSound;
    public bool canThrow = true;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && canThrow == true)
        {
            ThrowItem();
            throwSound.Play();
        }

    }

    IEnumerator DeleteObj(GameObject Item)
    {
        yield return new WaitForSeconds(.8f);
        Destroy(Item);
    }

    void ThrowItem()
    {
        GameObject Item = Instantiate(DiscoBall, transform.position, transform.rotation);
        Rigidbody rb = Item.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
        canThrow = false;
        StartCoroutine(DeleteObj(Item));
        Invoke("CanThrowAgain", 1f);
    }

    void CanThrowAgain()
    {
        canThrow = true;
    }

    void DestroyObj(GameObject Item)
    {
        Destroy(Item);
    }
}
