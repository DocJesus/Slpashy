using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().end = true;
            EnvironmentMovement.instance.StopMovement();
            GameInterphase.instance.SetWinningInterphase();
            other.tag = "Untagged";
        }
    }
}
