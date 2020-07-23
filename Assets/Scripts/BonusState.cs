using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameInterphase.instance.AddBonuses();
            //effet de particules de ses morts
            Destroy(gameObject);
        }
    }
}
