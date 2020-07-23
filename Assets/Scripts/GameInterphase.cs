using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInterphase : MonoBehaviour
{
    private int score = 0;
    private int nbBonuses = 0;

    public static GameInterphase instance;

    public Text pickUpObjectText;
    public Text levelText;
    public GameObject tutoriel;
    public Text scoreText;
    public Text gameOverScoreText;
    public Text winningScoreText;
    public GameObject gameOverPanel;
    public GameObject winningPanel;

    // Start is called before the first frame update
    void Start()
    {
        ResetToBasic();

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
        gameOverScoreText.text = scoreText.text;
        gameOverPanel.SetActive(true);
    }

    public void SetWinningInterphase()
    {
        winningScoreText.text = scoreText.text;
        winningPanel.SetActive(true);
        //mettre la coroutine pour que le score s'affiche bien
    }

    public void AddScore()
    {
        if (EnvironmentMovement.instance.movement)
            score += 1;
    }

    public void AddBonuses()
    {
        nbBonuses += 1;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
