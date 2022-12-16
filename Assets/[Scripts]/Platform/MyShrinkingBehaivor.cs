/*
Source File Name: MyShrinkingBehaivor.cs
Student Name: Giuliano Venturo Gonzales
StudentID: 1019819
Date Last Modified: 2022/12/15
Description: Shrink and Expand in a time given. Use a lerp always on update, but the var just change when the player enter or exits

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShrinkingBehaivor : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSourceShrinking;
    [SerializeField]
    AudioSource audioSourceExpanding;
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

    bool isShrinking;


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
        if ((percentageComplete > 1f) && audioSourceExpanding.isPlaying)
            audioSourceExpanding.Stop();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSourceExpanding.Stop();
            isShrinking = true;
            StartShirking();
            audioSourceShrinking.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSourceShrinking.Stop();
            isShrinking = false;
            StartExpanding();
            audioSourceExpanding.Play();
        }

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
