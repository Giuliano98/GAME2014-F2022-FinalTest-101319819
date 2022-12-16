using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShrinkingBehaivor : MonoBehaviour
{

    [SerializeField]
    Transform Platform;
    [SerializeField]
    float TotalTimeShrinking;
    [SerializeField]
    float TotalTimeExpand;
    Vector3 originalScale;
    Vector3 minimumScale;
    float tempElapsedTime;

    Vector3 init;
    Vector3 final;
    float timeTrans;
    float finalTime;
    float percentageComplete;



    private void Start()
    {
        originalScale = Platform.localScale;
        minimumScale = new Vector3(0.01f, originalScale.y, originalScale.z);

        StartExpanding();
    }

    private void Update()
    {
        tempElapsedTime += Time.deltaTime;
        percentageComplete = tempElapsedTime / finalTime;
        Platform.localScale = Vector3.Lerp(init, final, percentageComplete);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            StartShirking();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            StartExpanding();
    }



    void StartShirking()
    {
        init = originalScale;
        final = minimumScale;
        var timeLeft = TotalTimeShrinking * (Platform.localScale.x - final.x) / (init.x - final.x);
        timeTrans = TotalTimeShrinking - timeLeft;
        tempElapsedTime = timeTrans;
        finalTime = TotalTimeShrinking;
    }

    void StartExpanding()
    {
        init = minimumScale;
        final = originalScale;
        var timeLeft = TotalTimeExpand * (final.x - Platform.localScale.x) / (final.x - init.x);
        timeTrans = TotalTimeExpand - timeLeft;
        tempElapsedTime = timeTrans;
        finalTime = TotalTimeExpand;
    }
}
