/*
Source File Name:MyPlatformController.cs
Student Name: Giuliano Venturo Gonzales
StudentID: 1019819
Date Last Modified: 2022/12/15
Description: Set the Player as a child of the PlatformHolder. So this way when the platform shrink it will only affect the platform
and not the player

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlatformController : MonoBehaviour
{
    [SerializeField]
    Transform PlatformHolder;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.transform.SetParent(PlatformHolder);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.transform.SetParent(null);
    }
}
