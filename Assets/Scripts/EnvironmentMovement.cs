using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public float speed = 2f;

    private bool movement = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !movement)
        {
            movement = true;
        }
        if (movement)
        {
            transform.Translate(0f, 0f, -Time.deltaTime * speed);
        }
    }
}
