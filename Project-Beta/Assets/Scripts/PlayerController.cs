using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed at which the player moves unit 6 optimisation
    [SerializeField] protected float speed = 30.0f;
    // player's input for horizontal movement (left/right)
    [SerializeField] protected float horizontalInput;
    // Limits player's movement on the X-axis
    private float xRangeLeft = -8.0f;
    private float xRangeRight = 28.0f;
    //particle effects 
    public ParticleSystem explosion;
    public ParticleSystem dirtEffect;
    private SpawnManager spawnManager;
    public GamesManager GamesManager;

void Start()
{
    if (GamesManager == null)  // Check if it's not already assigned
    {
        GamesManager = FindObjectOfType<GamesManager>();
    }

    if (GamesManager == null)
    {
        Debug.LogError("GamesManager not found! Please assign it in the Inspector or ensure it's in the scene.");
    }
}

    void Update()
    {
        
        // Prevents the player from moving beyond the defined X-axis limits
        if (transform.position.x < xRangeLeft)
        {
            transform.position = new Vector3(xRangeLeft, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRangeRight)
        {
            transform.position = new Vector3(xRangeRight, transform.position.y, transform.position.z);
        }

        // Get horizontal input from the player 
        horizontalInput = Input.GetAxis("Horizontal");

        // Move the player left and right based on horizontal input
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (horizontalInput != 0)
            dirtEffect.Play();
        else
            dirtEffect.Stop();
    
    }

    // Called when the player collides with another object
    void OnCollisionEnter(Collision collision)
    {
        // This checks if the player collided with an object tagged as "Car"
        if (collision.gameObject.CompareTag("Car"))
        {
            GamesManager.GameOver();
            //playes explosion animation   
            explosion.Play();
        }
    }
}
