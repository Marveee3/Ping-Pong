using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]private float startSpeed;
    [SerializeField]private float extraSpeed;
    [SerializeField]private float maxExtraSpeed;

    private int hitCounter = 0;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        transform.position = new Vector3(0, 0, 0);
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        float x = Random.Range(0,2) == 0 ? -1 : 1;
        float y = Random.Range(0,2) == 0 ? -1 : 1;
        MoveBall(new Vector2(x, y));
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

    public void Restart()
    {
        StopAllCoroutines(); // Остановить все запущенные корутины
        rb.velocity = Vector2.zero; // Сбросить скорость до нуля
        StartCoroutine(Launch()); // Запустить процесс запуска мяча снова
    }


}
