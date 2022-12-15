using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlatformController : MonoBehaviour
{
    Vector3 tempWorldScale;
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tempWorldScale = other.gameObject.transform.localScale; // worldScale ref
            var scale = tempWorldScale;
            Vector3 signsEnter = new Vector3(Mathf.Sign(scale.x), Mathf.Sign(scale.y), Mathf.Sign(scale.z));    // Get signs

            other.gameObject.transform.SetParent(transform);
            var newScale = other.gameObject.transform.localScale;

            other.gameObject.transform.localScale = Vector3.Scale(tempWorldScale, newScale); // world * newLocal
            other.gameObject.transform.localScale = Vector3.Scale(other.gameObject.transform.localScale, signsEnter);  // mult per their sing before entering
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 tempLocalScale = other.gameObject.transform.localScale; // localScale on the platform
            var scale = tempLocalScale; // localScale ref
            Vector3 signsBeforeLeaving = new Vector3(Mathf.Sign(scale.x), Mathf.Sign(scale.y), Mathf.Sign(scale.z));    // Get the sign before leaving

            other.gameObject.transform.SetParent(null);

            Vector3 tempWorldScaleAbs = new Vector3(Mathf.Abs(tempWorldScale.x), Mathf.Abs(tempWorldScale.y), Mathf.Abs(tempWorldScale.z));
            other.gameObject.transform.localScale = Vector3.Scale(tempWorldScaleAbs, signsBeforeLeaving); // apply sign after leaving
        }
    }
}
