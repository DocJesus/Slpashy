using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogWarning("Double instance GameManager");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
