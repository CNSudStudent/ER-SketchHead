using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    //Rigidbody2D object that is stored
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    //downward speed of the object
    [Header("Default Down Speed")]
    public float downSpeed = 20f;
    //movemnet speed of the object
    [Header("Default Movement Speed")]
    public float movementSpeed = 10f;
    //movement direction of the object
    [Header("Default Directional Movement Speed")]
    public float movement = 0f;
    //Score of game
    [Header("Score Text")]
    public Text scoreText;
    private float topScore = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //varible equals to component Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement equals Horizontal movement
        //multiplied by the movement speed
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        //if direction on x axis is less than 0
        if (movement < 0)
        {
            //object faces to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        //if direction on x axis is greater than 0
        else
        {
            //object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        //if players velocity is greater than 0
        //and position on the y axis is greater
        //than the score
        if (rb.velocity.y > 0 && transform.position.y > topScore)
        {
            //score equals players position
            topScore = transform.position.y;
        }
        //Text for the score equals to the top score
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
    }

    private void FixedUpdate()
    {
        //Vector2 which is (x,y) velocity
        //equals to the velocity of the rigidbody2D
        Vector2 velocity = rb.velocity;
        //Velocity of the x axis equals to
        //the directtion movement on the x axis
        // pf the chaacter.
        velocity.x = movement;
        //Rigidbody2D velocity equals to
        //velocity of the object
        rb.velocity = velocity;
    }

    //Collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocity = rb.velocity;
        if (velocity.y <= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
        }
    }
}