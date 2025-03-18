using UnityEngine;
using UnityEngine.SceneManagement;


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
        LaunchBall();
    }

    void LaunchBall()
    {   
        //set ball to center of the screen
        transform.position = Vector2.zero; // same as 0,0

        //reset ball speed to starting speed
        ballCurrentSpeed = ballStartingSpeed;

        float xDirection = Random.Range(-1f, 1f);
        float yDirection = Random.Range(-1f, 1f);

        direction = new Vector2(xDirection, yDirection);

        //Notice! Unity 6 = rb.linearVelocity, Unity <= 2022.3 rb.velocity

        //Vector2 normalizedDirection = direction.normalized; //returns new vector2

        direction.Normalize(); //does not return, but affects the given vector directly

        rb.linearVelocity = direction * ballCurrentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ballCurrentSpeed++; //or ballSpeed = ballSpeed +1 or ballSpeed +=1
            rb.linearVelocity = rb.linearVelocity.normalized * ballCurrentSpeed;
        }
    //    if(collision.gameObject.CompareTag("Wall"))
    //    {

    //        Vector2 velocity = rb.linearVelocity;

    //        Vector2 normal = collision.GetContact(0).normal; //collision.contacts[0].normal;
            
    //        rb.linearVelocity = Vector2.Reflect(velocity, normal);
    //    }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER ACTIVATED");

        //vaihdetaan testiksi sceneä
        SceneManager.LoadScene("Level 2");

        //RESETOIDAAN PALLON POSITIO KESKELLE
        //LAUKAISTAAN PALLO ALKUNOPEUDELLA (ei uudella nopeudella)
        //LaunchBall();              

        //LISÄTÄÄN KO. PELAAJAN PISTEITÄ YHDELLÄ

        
    }


}
