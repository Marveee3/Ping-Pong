using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] BallMovement ballMovement;
    [SerializeField] ScoreManager scoreManager;

    private AudioSource audioSource;
    private AudioClip hitSound;

    private void Awake()
    {
        ballMovement = FindObjectOfType<BallMovement>();
        scoreManager = FindObjectOfType<ScoreManager>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        GameObject prefab = Resources.Load<GameObject>("HitSound");
        if (prefab != null)
        {
            AudioSource prefabSource = prefab.GetComponent<AudioSource>();
            if (prefabSource != null)
            {
                hitSound = prefabSource.clip;
                audioSource.volume = prefabSource.volume;
            }
        }
    }

    void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player 1")
            positionX = 1;
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;
        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
            
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "Player 2")
        {
            Bounce(collision);
            if (hitSound != null && audioSource != null)
                audioSource.PlayOneShot(hitSound);
        }

        if(collision.gameObject.name == "Right Border")
        {
            scoreManager.Player1Score();
            ballMovement.Restart();
        }
        else if(collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Score();
            ballMovement.Restart();
        }
    }
}
