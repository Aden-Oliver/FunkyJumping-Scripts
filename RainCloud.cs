using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RainCloud : MonoBehaviour
{
    public int health = 100;
    public float radius = 10f;
    public GameObject Enemy;
    public Transform target;
    public Transform Me;
    public float speed = 4f;
    public float rotationSpeed = 4f;
    public FPSInput player;

    IEnumerator doDamage()
    {
        yield return new WaitForSeconds(.8f);
        StartCoroutine(doDamage());
        player.damage(10);
        //StartCoroutine(doDamage());
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(Enemy);
        }

        Me.rotation = Quaternion.Slerp(Me.rotation, Quaternion.LookRotation(target.position - Me.position), rotationSpeed * Time.deltaTime);

        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= radius)
        {
            Me.position += Me.forward *= speed * Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "DiscoBall(Clone)")
        {
            health -= 50;
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player2")
        {
            StartCoroutine(doDamage());
        }
    }

    private void OnTriggerExit(Collider col)
    {
        StopAllCoroutines();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
