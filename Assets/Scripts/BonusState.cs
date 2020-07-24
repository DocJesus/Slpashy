using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusState : MonoBehaviour
{
    public float speed;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //audioSource.PlayOneShot(sound);
            AudioSource.PlayClipAtPoint(sound, transform.position, 1f);

            GameInterphase.instance.AddBonuses();
            Destroy(gameObject);
        }
    }
}
