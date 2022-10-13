using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerValue;
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    bool isAnsweringQuestion = false;
    float fillFraction;
    bool loadNextQuestion;

    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (timerValue > 0)
        {
            if (isAnsweringQuestion)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (isAnsweringQuestion)
            {
                timerValue = timeToShowCorrectAnswer;
                isAnsweringQuestion = false;
            }
            else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }
    }

    public float GetFillFraction()
    {
        return fillFraction;
    }

    public bool GetIsAnsweringQuestion()
    {
        return isAnsweringQuestion;
    }

    public bool GetLoadNextQuestion()
    {
        return loadNextQuestion;
    }

    public void SetLoadNextQuestionFalse()
    {
        loadNextQuestion = false;
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
}
