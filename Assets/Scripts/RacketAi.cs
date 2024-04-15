using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAi : MonoBehaviour
{
    [SerializeField] private float racketSpeed;
    [SerializeField]private GameObject ball;
    private Rigidbody2D rb;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(TrackBallPosition());
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;
        rb.velocity = direction * racketSpeed;
    }

    IEnumerator TrackBallPosition()
    {
        while (true)
        {
            if (ball != null)
            {
                targetPosition = ball.transform.position;
                rb.velocity = Vector2.zero; // Сбросить скорость ракетки
                yield return new WaitForSeconds(0.1f); // Подождать немного перед обновлением позиции мяча
            }
            else
            {
                yield return null;
            }
        }
    }
}
