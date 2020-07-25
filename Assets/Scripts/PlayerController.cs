using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float bounceForce;
    public Rigidbody rig;
    public GameObject jumpParticules;
    public AudioClip sound;
    public float speed;
    public bool end = false;

    private Vector2 startPos;
    private Vector2 direction;
    private Vector2 prePos;

    private Vector3 movement;
    private Vector3 position;
    private float width;

    private AudioSource audioSource;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        position = transform.position;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.y < 0)
            rig.AddForce(new Vector3(0f, -bounceForce, 0f));

        if (Input.touchCount > 0 && !end)
        {
            rig.constraints = RigidbodyConstraints.None;

            Touch touch = Input.GetTouch(0);

            //startPos = touch.position;
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    prePos = touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = touch.position - prePos;
                    prePos = touch.position;
                    break;
                /*
            case TouchPhase.Ended:
                startPos = Vector2.zero;
                break;
                */

                case TouchPhase.Stationary:
                    direction = Vector2.zero;
                    //startPos = Vector2.zero;
                    break;
            }

            //Debug.Log("direction = " + direction);

            //direction = direction.normalized;
            direction.x = (direction.x * 8) / (width);
            //direction.x = direction.x / dicoto;

            //Debug.Log("toto = " + direction);

            movement.Set(direction.x, 0f, 0f);

            rig.MovePosition((transform.position + movement * speed * Time.deltaTime));
        }
    }

    private void FixedUpdate()
    {
        //rig.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!end)
        {
            if (EnvironmentMovement.instance.movement)
                audioSource.PlayOneShot(sound);

            GameObject obj = Instantiate(jumpParticules);
            obj.transform.position = collision.transform.position;
            Destroy(obj, 1f);
            GameInterphase.instance.AddScore();
        }
        rig.velocity = Vector3.zero;
        rig.AddForce(new Vector3(0f, bounceForce * 7.5f, 0f));

    }

    public void StopAll()
    {
        rig.constraints = RigidbodyConstraints.FreezeAll;
        end = true;
    }
}
