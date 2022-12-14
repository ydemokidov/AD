using UnityEngine;

public class sc_player_AD : MonoBehaviour
{
    

    public Vector2 speed = new Vector2(10, 10);

    private Vector2 movement;

    void Update()
    {
        
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(
          speed.x * inputX,
          speed.y * inputY);

    }

    void FixedUpdate()
    {
        
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}