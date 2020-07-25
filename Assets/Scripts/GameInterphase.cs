using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInterphase : MonoBehaviour
{
    private int score = 0;
    private int nbBonuses = 0;
    private int nbCombo = 0;
    private float timer = 0;

    public static GameInterphase instance;

    public Text pickUpObjectText;
    public Text levelText;
    public GameObject tutoriel;
    public Text scoreText;
    public Text gameOverScoreText;
    public Text winningScoreText;
    public GameObject gameOverPanel;
    public GameObject winningPanel;
    public Text comboText;
    public float comboTimer;
    public Slider slider;
    public Animator comboAnim;

    public Fadder fader;

    public Image star1;
    public Image star2;
    public Image star3;

    // Start is called before the first frame update
    void Start()
    {
        ResetToBasic();
        comboText.enabled = false;

        if (instance != null)
        {
            Debug.LogError("double instance GameInterphase");
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        pickUpObjectText.text = nbBonuses.ToString();
        scoreText.text = score.ToString();

        if (timer <= 0)
        {
            nbCombo = 0;
            timer = comboTimer;
            comboText.enabled = false;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void ResetToBasic()
    {
        score = 0;
        nbBonuses = 0;
        SetDefaultInterphase();
    }

    public void SetPlayingInterphase()
    {
        levelText.enabled = false;
        tutoriel.SetActive(false);
        scoreText.enabled = true;
    }

    public void SetDefaultInterphase()
    {
        levelText.enabled = true;
        tutoriel.SetActive(true);
        scoreText.enabled = false;
    }

    public void SetGameOverInterphase()
    {
        gameOverPanel.SetActive(true);
        float z = EnvironmentMovement.instance.transform.position.z;
        float prct = -(100 * z) / 94;

        Debug.Log("prct = " + prct);

        StartCoroutine(AffGOScore());
        StartCoroutine(AffGOSlider(prct));
    }

    IEnumerator AffGOScore()
    {
        int tmpScore = 0;

        while (tmpScore < score)
        {
            tmpScore += 1;
            gameOverScoreText.text = tmpScore.ToString();
            yield return new WaitForSeconds(0.01f);
        }
        yield return 0;
    }

    IEnumerator AffGOSlider(float prct)
    {
        float value = 0;

        while (value < prct)
        {
            value += 1;
            slider.value = value;
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void SetWinningInterphase()
    {
        winningPanel.SetActive(true);

        StartCoroutine(AffScore());

        winningScoreText.text = scoreText.text;
    }

    IEnumerator AffScore()
    {
        int tmpScore = 0;

        while (tmpScore < score)
        {
            tmpScore += 1;
            winningScoreText.text = tmpScore.ToString();
            if (tmpScore >= 13)
                star1.color = new Color(255f, 255f, 255f, 255f);
            if (tmpScore >= 58)
                star2.color = new Color(255f, 255f, 255f, 255f);
            if (tmpScore >= 100)
                star3.color = new Color(255f, 255f, 255f, 255f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return 0;
    }

    public void AddCombo()
    {
        timer = comboTimer;
        nbCombo += 1;

        if (nbCombo > 1)
        {
            comboAnim.SetTrigger("PopUp");
            comboText.enabled = true;
            comboText.text = "Combo X" + nbCombo;
        }
    }

    public void AddScore()
    {
        if (EnvironmentMovement.instance.movement)
            score += 1 + nbCombo;
    }

    public void AddBonuses()
    {
        nbBonuses += 1;
    }

    public void Replay()
    {
        fader.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
