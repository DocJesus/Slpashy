using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] dontDestroy;
    public static GameManager instance;

    public bool gameLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in dontDestroy)
        {
            DontDestroyOnLoad(obj);
        }

        if (instance != null)
        {
            Debug.LogWarning("Double instance GameManager");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
