﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject pointText;
    public GameObject perfectText;
    public Transform invoquePoint;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //set l'animation
            anim.SetTrigger("Jumped");
            GameObject obj = Instantiate(pointText);
            obj.transform.position = invoquePoint.position;
            Destroy(obj, 1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameInterphase.instance.AddCombo();
            GameObject obj = Instantiate(perfectText);
            obj.transform.position = invoquePoint.position + new Vector3(0, 1, 0);
            Destroy(obj, 1.5f);
        }
    }

}
