using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int maxScore;

    private int p1Score;
    private int p2Score;

    [SerializeField] private Text p1Text;
    [SerializeField] private Text p2Text;

    private SceneTransition sceneTransition;

    void Start()
    {
        sceneTransition = FindObjectOfType<SceneTransition>();
    }

    private void Update()
    {
        UpdateScoreText();
        CheckForGameOver();
    }

    private void UpdateScoreText()
    {
        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();
    }

    private void CheckForGameOver()
    {
        if (p1Score >= maxScore || p2Score >= maxScore)
        {
            DetermineWinner();
        }
    }

    private void DetermineWinner()
    {
        bool isPlayer1Win = p1Score > p2Score;
        PlayerPrefs.SetInt("isPlayer1Win", isPlayer1Win ? 1 : 0);
        sceneTransition.TransitionToScene(4);
    }

    public void Player1Score()
    {
        p1Score++;
    }

    public void Player2Score()
    {
        p2Score++;
    }
}
