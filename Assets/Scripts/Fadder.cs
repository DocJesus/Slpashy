using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadder : MonoBehaviour
{
    public float speed;
    public Image screenFadder;

    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadScene(string name)
    {
        StartCoroutine(FadeOut(name));
    }

    IEnumerator FadeIn()
    {
        float t = 0f;

        while (t < 1)
        {
            t += Time.deltaTime * speed;

            float a = curve.Evaluate(t);

            screenFadder.color = new Color(0, 0, 0, a);

            yield return 0;
        }
    }

    IEnumerator FadeOut(string _scene)
    {
        float t = 1f;

        while (t > 0)
        {
            t -= Time.deltaTime * speed;

            float a = curve.Evaluate(t);

            screenFadder.color = new Color(0, 0, 0, a);

            yield return 0;
        }
        SceneManager.LoadScene(_scene);
    }
}
