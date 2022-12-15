using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShrinkingBehaivor : MonoBehaviour
{
    [Header("Platform Reference")]
    [SerializeField]
    Transform platform;
    [SerializeField]
    float TotalTimeShrinking;
    [SerializeField]
    bool bContinueShrinking;
    Vector3 originalScale;
    Vector3 minimumScale;


    private void Start()
    {
        originalScale = platform.localScale;
        minimumScale = new Vector3(0.01f, originalScale.y, originalScale.z);
        bContinueShrinking = false;

    }
    private void Update()
    {
        if (bContinueShrinking)
            transform.localScale = LerpScale(transform.localScale, minimumScale, TotalTimeShrinking);
    }

    Vector3 LerpScale(Vector3 init, Vector3 final, float totalTime)
    {
        float continueTimeToLerp = Mathf.Abs(init.x - final.x) * totalTime / Mathf.Abs(originalScale.x - minimumScale.x);

        return Vector3.Lerp(init, final, continueTimeToLerp);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            bContinueShrinking = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            bContinueShrinking = false;
    }
}
