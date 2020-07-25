using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public static EnvironmentMovement instance;
    public float speed = 2f;

    public bool movement = false;

    [SerializeField]
    private bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogError("double instance environementMovement");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !movement && !end)
        {
            movement = true;
            GameInterphase.instance.SetPlayingInterphase();
        }
        if (movement)
        {
            transform.Translate(0f, 0f, -Time.deltaTime * speed);
        }
        //attention à l'arret du décors
    }

    public void StopMovement()
    {
        movement = false;
        end = true;
    }
}
