using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text gameOverText;
    [SerializeField] Button resetButton;

    private int score = 0;

    private bool m_gameOver;
    public bool gameOver
    {
        get
        {
            return m_gameOver;
        }
        set
        {
            m_gameOver = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_gameOver = false;
        UpdateScore(0);
    }

    //ABSTRACTION
    // Add to the current score
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // ABSTRACTION
    // Trigger a game over state
    public void GameOver()
    {
        m_gameOver = true;
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
    }

    // Restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
