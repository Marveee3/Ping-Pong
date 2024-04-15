using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int p1Score;
    private int p2Score;

    [SerializeField]private Text p1Text;
    [SerializeField]private Text p2Text;

    private void Update()
    {
        p1Text.text = p1Score.ToString();
        p2Text.text = p2Score.ToString();        
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