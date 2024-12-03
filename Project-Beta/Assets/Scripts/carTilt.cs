using UnityEngine;

public class carTilt : MonoBehaviour
{
    // Maximum tilt angle
    public float tiltAmount = 10f;  

    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // calculate tilt based on the input, direct rotation on the Z-axis
        transform.rotation = Quaternion.Euler(0, 0, -horizontalInput * tiltAmount);
    }
}
