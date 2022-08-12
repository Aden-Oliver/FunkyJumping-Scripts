using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject platform;
    public float speed;
    private Vector3 start;
    private Vector3 end;

    IEnumerator PlatformMove(GameObject obj, Vector3 target, float speed)
    {
        Vector3 start = obj.transform.position;
        float time = 0f;

        while (obj.transform.position != target)
        {
            obj.transform.position = Vector3.Lerp(start, target, time/Vector3.Distance(start, target)*speed);
            time += Time.deltaTime;
            yield return null;
        }
    }

    void Start()
    {
        start = startPoint.transform.position;
        end = endPoint.transform.position;
        StartCoroutine(PlatformMove(platform, end, speed));
    }

    void Update()
    {
        if(transform.position == end)
        {
            StartCoroutine(PlatformMove(platform, start, speed));
        }

        if (transform.position == start)
        {
            StartCoroutine(PlatformMove(platform, end, speed));
        }
    }
}
