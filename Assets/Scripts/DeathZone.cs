using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public AudioClip clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //freeze le player
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.GetComponent<PlayerController>().StopAll();

            //son pour dire qu'on est mort
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0), 2f);

            //stoper l'environement qui bouge
            EnvironmentMovement.instance.StopMovement();
            //apparition du canvas de GameOver
            GameInterphase.instance.SetGameOverInterphase();
        }
    }
}
