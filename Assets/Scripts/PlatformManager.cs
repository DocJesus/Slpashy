using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject pointText;
    public GameObject perfectText;
    public Transform invoquePoint;

    private Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(JumpAnim());
            GameObject obj = Instantiate(pointText);
            obj.transform.position = invoquePoint.position;
            Destroy(obj, 1.5f);
        }
    }

    IEnumerator JumpAnim()
    {
        float t = 0f;
        Vector3 newScale = Vector3.zero;
        Vector3 newPos = Vector3.zero;

        while (t < 1)
        {
            t += Time.deltaTime;

            if (trans.localScale.x < 2 && trans.localScale.z < 2)
            {
                newScale.Set(trans.localScale.x + t, trans.localScale.y, trans.localScale.z + t);
                trans.localScale = newScale;
            }

            if (trans.localScale.x >= 2 && trans.localScale.z >= 2)
            {
                newScale.Set(trans.localScale.x - t, trans.localScale.y, trans.localScale.z - t);
                trans.localScale = newScale;
                newPos.Set(trans.position.x, trans.position.y - t, trans.position.z);
                trans.position = newPos;
            }

            yield return 0;
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
