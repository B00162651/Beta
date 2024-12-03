using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] public float speed = 150f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//move spawn car towards mine
         transform.Translate(Vector3.forward * speed * Time.deltaTime);
         if (transform.position.x < -50) 
        {
            Destroy(gameObject);
        }
    }
}