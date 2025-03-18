using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float ballSpeed = 5f;
    
    Vector2 direction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        LaunchBall();
    }

    void LaunchBall()
    {
        float xDirection = Random.Range(-1f, 1f);
        float yDirection = Random.Range(-1f, 1f);

        direction = new Vector2(xDirection, yDirection);

        //Notice! Unity 6 = rb.linearVelocity, Unity <= 2022.3 rb.velocity

        //Vector2 normalizedDirection = direction.normalized; //returns new vector2

        direction.Normalize(); //does not return, but affects the given vector directly

        rb.linearVelocity = direction * ballSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballSpeed++; //or ballSpeed = ballSpeed +1 or ballSpeed +=1
            rb.linearVelocity = rb.linearVelocity.normalized * ballSpeed;
        }
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {

    //        Vector2 velocity = rb.linearVelocity;

    //        Vector2 normal = collision.GetContact(0).normal; //collision.contacts[0].normal;
            
    //        rb.linearVelocity = Vector2.Reflect(velocity, normal);
    //    }        
    }


}
