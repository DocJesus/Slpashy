using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float bounceForce;
    public Rigidbody rig;

    private Vector3 prevPosition;
    private Vector3 position;
    private float width;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.y < 0)
            rig.AddForce(new Vector3(0f, -bounceForce, 0f)); 

        if (Input.touchCount > 0)
        {
            rig.constraints = RigidbodyConstraints.None;

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 pos = touch.position;

                pos.x = (pos.x - width) / width;
                pos.x = pos.x * 2;
                position = new Vector3(pos.x, transform.position.y, transform.position.z);

                transform.position = position;
                prevPosition = position;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("je rentre dan sun truc");
        rig.AddForce(new Vector3(0f, bounceForce, 0f));
    }
}
