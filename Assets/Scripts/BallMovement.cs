using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]private float startSpeed;
    [SerializeField]private float extraSpeed;
    [SerializeField]private float maxExtraSpeed;

    [SerializeField]private float minX = -8.45f;
    [SerializeField]private float maxX = 8.45f;
    [SerializeField]private float minY = -4.55f;
    [SerializeField]private float maxY = 4.55f;

    private int hitCounter = 0;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        StartCoroutine(Launch());
    }

    void Update()
    {
        ClampInsideField();
    }

    void ClampInsideField()
    {
        Vector3 pos = transform.position;
        float clampedX = Mathf.Clamp(pos.x, minX, maxX);
        float clampedY = Mathf.Clamp(pos.y, minY, maxY);

        if(Mathf.Abs(pos.x - clampedX) > 0.0001f)
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        if(Mathf.Abs(pos.y - clampedY) > 0.0001f)
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);

        transform.position = new Vector3(clampedX, clampedY, pos.z);
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
