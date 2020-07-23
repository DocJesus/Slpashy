using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnvironmentMovement.instance.StopMovement();
            GameInterphase.instance.SetWinningInterphase();
            other.tag = "Untagged";
        }
    }
}
