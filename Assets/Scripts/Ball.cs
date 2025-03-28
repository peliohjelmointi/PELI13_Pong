using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float ballStartingSpeed = 5f;
    float ballCurrentSpeed;

    Vector2 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {        
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
        ballCurrentSpeed = ballStartingSpeed;
        rb.linearVelocity = direction * ballCurrentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballCurrentSpeed++;
        }

        Vector2 normal = collision.GetContact(0).normal; //collision.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal);
        rb.linearVelocity = direction * ballCurrentSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // kumpaan triggeriin osutaan?
        // luodaan GameManageriin AddScore(int player) ja kutsutaan sitä
        if (collision.CompareTag("GoalLeft")) //2.pelaaja scores
            GameManager.Instance.AddScore(2); // pelaajan numero parametrina

        else if (collision.CompareTag("GoalRight"))
            GameManager.Instance.AddScore(1);

        //asetaan pallo keskelle
        transform.position = Vector2.zero;
        
        //arvotaan uusi suunta
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f)).normalized;
        //resetoidaan nopeus takaisin alkunopeudeksi
        ballCurrentSpeed = ballStartingSpeed;
        //pallo liikkeelle
        rb.linearVelocity = direction * ballStartingSpeed;
    }

}




