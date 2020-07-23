using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //freeze le player
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            other.GetComponent<PlayerController>().StopAll();

            //petite animation sur la caméra pour dire qu'on est mort

            //stoper l'environement qui bouge
            EnvironmentMovement.instance.StopMovement();
            //apparition du canvas de GameOver
            GameInterphase.instance.SetGameOverInterphase();
        }
    }
}
