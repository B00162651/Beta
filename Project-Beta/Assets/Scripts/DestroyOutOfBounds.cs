using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Define the boundary limits
    [SerializeField] private float topBound = 1000;  // The Z position beyond which the object will be destroyed
    [SerializeField] private float lowerBound = -5; // The Z position below which the object will be destroyed   

    private GamesManager gamesManager; // Reference to GamesManager

    void Start()
    {
        // Find the GamesManager in the scene
        gamesManager = FindObjectOfType<GamesManager>();

        // Check if GamesManager was found
        if (gamesManager == null)
        {
            Debug.LogError("GamesManager not found in the scene. Make sure it is present.");
        }
    }

    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowerBound)
        {
            if (gamesManager != null)
            {
                Debug.Log("Car passed boundary, updating score");
                // not working gamesManager.UpdateScore(5);  // Update score when car passes bounds
            }

            Debug.Log("Destroying car at position: " + transform.position);  // Log car destruction

            Destroy(gameObject);  // Destroy the car
        }
    }

}