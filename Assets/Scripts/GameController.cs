using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class GameController : MonoBehaviour
{
    public Text scoreDisplay;
    public Text questionText;
    public Text timeRemainingDisplay;
    public GameObject questionDisplayPanel;
    public GameObject roundDisplayPanel;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    public Boolean isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerbuttonGameObjects = new List<GameObject>();
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.question;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        questionIndex = Random.Range(0, questionPool.Length);
        playerScore = 0;
        ShowQuestion();
        isRoundActive = false;
        UpdateTimeRemainingDisplay();
        
    }

    private void ShowQuestion()
    {
        RemoveAnswerButton();
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;

        for (int i = 0; i < questionData.answer.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerbuttonGameObjects.Add(answerButtonGameObject);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.AnswerSetup(questionData.answer[i]);
        }
    }

    private void RemoveAnswerButton()
    {
        while (answerbuttonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerbuttonGameObjects[0]);
            answerbuttonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
//        if (isCorrect)
//        {
//            playerScore += currentRoundData.pointAddedForCorrextAnswer;
//            scoreDisplay.text = "Score : " + playerScore.ToString();
//        } 
//        if (questionPool.Length > questionIndex + 1)
//        {
//            questionIndex++;
//            ShowQuestion();
//        } else
//        {
//            EndRound();
//        }
        if (isCorrect)
        {
            EndRound();
        }
        else
        {
            questionIndex = Random.Range(0, questionPool.Length);
            ShowQuestion();
        }
        
        
    }

    public void EndRound()
    {
        isRoundActive = false;
        BoxScript.activeBox = false;
        questionDisplayPanel.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void StartRound()
    {
        isRoundActive = true;
        questionDisplayPanel.SetActive(true);
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplay.text = "Time : " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();
            if (timeRemaining <= 0)
            {
                EndRound();
            }
        }
    }
    
    
}
