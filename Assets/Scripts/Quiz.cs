using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    // Start is called before the first frame update
    void Start()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < 3; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Oikein!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            int correctIndex = question.GetCorrectAnswerIndex();
            questionText.text = "Oikea vastaus on\n" + question.GetAnswer(correctIndex);
            buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
