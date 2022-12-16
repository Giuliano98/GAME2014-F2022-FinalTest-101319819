/*
Source File Name: MyMovingPlatform.cs
Student Name: Giuliano Venturo Gonzales
StudentID: 1019819
Date Last Modified: 2022/12/15
Description: Move the gameObject between points (Positions)

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovingPlatform : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform[] arrPoints;
    int index;

    private void Start()
    {
        index = 0;
        // move the platform to the first point
        transform.position = arrPoints[index].position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, arrPoints[index].position) < 0.03f)
            index = (index + 1 == arrPoints.Length) ? 0 : index + 1;

        transform.position = Vector2.MoveTowards(transform.position, arrPoints[index].position, speed * Time.deltaTime);
    }

}
