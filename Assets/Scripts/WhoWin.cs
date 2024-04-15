using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoWin : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject racket;
    private SpriteRenderer racketSpriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        racketSpriteRenderer = racket.GetComponent<SpriteRenderer>();

        bool isPlayer1Win = PlayerPrefs.GetInt("isPlayer1Win", 0) == 1;

        if (isPlayer1Win)
        {
            spriteRenderer.color = new Color(0, 1, 0.69f); // Цвет 00FFB0 в RGB
            racketSpriteRenderer.color = new Color(0, 1, 0.69f); // Цвет 00FFB0 в RGB
        }
        else
        {
            spriteRenderer.color = new Color(0, 0.53f, 1); // Цвет 0087FF в RGB
            racketSpriteRenderer.color = new Color(0, 0.53f, 1); // Цвет 0087FF в RGB
        }
    }
}
