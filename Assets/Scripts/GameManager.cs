using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] dontDestroy;

    public bool gameLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in dontDestroy)
        {
            //si il existe pas alors on l'instancie + on le détruit pas svp
            if (GameObject.FindGameObjectWithTag("Music") == null)
            {
                GameObject tmp = Instantiate(obj);
                DontDestroyOnLoad(tmp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
