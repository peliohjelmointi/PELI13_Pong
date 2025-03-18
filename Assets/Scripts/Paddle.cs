using UnityEditor.Rendering;
using UnityEngine;

public class Paddle : MonoBehaviour
{    
    [SerializeField] float moveSpeed; //private (ei näy muihin skripteihin, 
                                      // mutta serializefield mahdollistaa editorista asettamisen
    float clampY = 3.5f;

    private void Update()
    {
        GetPaddleInput();   
    }

    void GetPaddleInput()
    {
                                // Vertical = ArrowUp, ArrowDown, W, S
                            //returns 1 or -1
        // Get move direction from player (up or down
        float moveDirection = Input.GetAxisRaw("Vertical");

        // Calculate new position for moving
        float newYPosition = transform.position.y + moveDirection * moveSpeed * Time.deltaTime;

        // Clamp the y position to keep the paddle within bounds
        float clampedY = Mathf.Clamp(newYPosition, -clampY, clampY); //between -3.5 and 3.5

        // Movement of the paddle within clamped values
        transform.position = new Vector2(transform.position.x, clampedY);
    }
}
