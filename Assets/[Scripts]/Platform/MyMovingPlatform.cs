using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovingPlatform : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    int startingPoint;
    [SerializeField]
    Transform[] points;
    int i = 0;

    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            i = (i + 1 == points.Length) ? 0 : i + 1;

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

}
