using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject pointText;
    public GameObject perfectText;
    public Transform invoquePoint;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision depuis la platform");

        GameObject obj = Instantiate(pointText);
        obj.transform.position = invoquePoint.position;
        Destroy(obj, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = Instantiate(perfectText);
        obj.transform.position = invoquePoint.position + new Vector3(0, 1, 0);
        Destroy(obj, 1.5f);
    }
}
