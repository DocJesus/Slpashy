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

    private Vector3 movement;
    private Vector3 position;
    private float width;
    private bool end = false;
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
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;

                pos.x = (pos.x - width) / width;
                //Debug.Log(pos.x);
                pos.x = pos.x * 4;

                movement.Set(pos.x - transform.position.x, 0f, 0f);
                //movement = movement.normalized * 5.1f * Time.deltaTime;

                //position = new Vector3(pos.x, transform.position.y, transform.position.z);
                //transform.position = position;
                rig.MovePosition(transform.position + movement);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(sound);
        GameObject obj = Instantiate(jumpParticules);
        obj.transform.position = collision.transform.position;
        Destroy(obj, 1f);
        GameInterphase.instance.AddScore();
        rig.velocity = Vector3.zero;
        rig.AddForce(new Vector3(0f, bounceForce * 7.5f, 0f));
    }

    public void StopAll()
    {
        rig.constraints = RigidbodyConstraints.FreezeAll;
        end = true;
    }
}
