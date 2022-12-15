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
    float elapsedTimeShrinking;
    bool bContinueShrinking;
    Vector3 originalScale;
    Vector3 minimumScale;

    float tempElapsedTime;

    private void Start()
    {
        originalScale = platform.localScale;
        minimumScale = new Vector3(0.01f, originalScale.y, originalScale.z);
        bContinueShrinking = false;
        //elapsedTimeShrinking = 0.001f;
    }
    private void Update()
    {
        if (bContinueShrinking)
        {
            tempElapsedTime += Time.deltaTime;
            float percentageComplete = tempElapsedTime / TotalTimeShrinking;
            platform.localScale = Vector3.Lerp(originalScale, minimumScale, percentageComplete);
        }
        //platform.localScale = LerpScale(platform.localScale, minimumScale, ref elapsedTimeShrinking, TotalTimeShrinking);
    }

    Vector3 LerpScale(Vector3 init, Vector3 final, ref float elapsedTime, float totalTime)
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / totalTime;
        Debug.Log(elapsedTime);
        return Vector3.Lerp(init, final, percentageComplete);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            bContinueShrinking = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            bContinueShrinking = false;
    }
}
