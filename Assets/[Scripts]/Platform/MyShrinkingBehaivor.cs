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
    float TotalTimeExpand;
    [SerializeField]
    Vector3 originalScale;
    [SerializeField]
    Vector3 minimumScale;
    [SerializeField]
    float tempElapsedTime;

    [SerializeField]
    Vector3 init;
    [SerializeField]
    Vector3 final;
    [SerializeField]
    float timeTrans;
    [SerializeField]
    float finalTime;
    [SerializeField]
    float percentageComplete;



    private void Start()
    {
        originalScale = platform.localScale;
        minimumScale = new Vector3(0.01f, originalScale.y, originalScale.z);
        StartExpanding();
    }
    private void Update()
    {
        // if (bContinueShrinking)
        // {
        //     tempElapsedTime += Time.deltaTime;
        //     var tempDeltaScaleX = originalScale.x - platform.localScale.x;
        //     var percentageScale =  tempDeltaScaleX / platform.localScale.x;

        //     float T2 = TotalTimeShrinking * tempElapsedTime / TotalTimeShrinking;
        //     platform.localScale = Vector3.Lerp(originalScale, minimumScale, percentageComplete);
        //     TotalTimeExpand = 0f;
        // }
        // else
        // {

        tempElapsedTime += Time.deltaTime;
        percentageComplete = tempElapsedTime / finalTime;
        platform.localScale = Vector3.Lerp(init, final, percentageComplete);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartShirking();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartExpanding();
        }
    }

    void StartShirking()
    {
        init = originalScale;
        final = minimumScale;
        var timeLeft = TotalTimeShrinking * (platform.localScale.x - final.x) / (init.x - final.x);
        timeTrans = TotalTimeShrinking - timeLeft;
        tempElapsedTime = timeTrans;
        finalTime = TotalTimeShrinking;
        Debug.Log("StartShirking in seconds: " + timeLeft);
    }

    void StartExpanding()
    {
        init = minimumScale;
        final = originalScale;
        var timeLeft = TotalTimeExpand * (final.x - platform.localScale.x) / (final.x - init.x);
        timeTrans = TotalTimeExpand - timeLeft;
        tempElapsedTime = timeTrans;
        finalTime = TotalTimeExpand;
        Debug.Log("start expanding in seconds: " + timeLeft);
    }
}
