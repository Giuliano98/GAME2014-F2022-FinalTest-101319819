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
