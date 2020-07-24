using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusState : MonoBehaviour
{
    public float speed;
    public AudioClip sound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot(sound);
            GameInterphase.instance.AddBonuses();
            //effet de particules de ses morts
            Destroy(gameObject, 0.6f);
        }
    }
}
