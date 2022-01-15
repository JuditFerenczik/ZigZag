using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gameStarted;
    public int score;
    //public Text scoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highscoreText;
    private void Awake()
    {
        highscoreText.text = "Best: " + GetHighScore().ToString();
    }
    public void StartGame()
    {
        FindObjectOfType<Road>().StartBulding();
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);

    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString(); 
        Debug.Log(score);
        if(score >GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscoreText.text = score.ToString();
        }
    }
    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
