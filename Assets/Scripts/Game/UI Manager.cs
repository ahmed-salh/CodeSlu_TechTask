using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Transform startPanel, pausePanel, gamaOverPanel;

    [SerializeField]
    private TMP_Text scoreText, highScore;

    [SerializeField]
    private PlayerStats stats;

    private void OnEnable()
    {
        GameplayEventsHandler.onScore += stats.AddScore;
        GameplayEventsHandler.onScore += UpdateScore;
        GameplayEventsHandler.onGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameplayEventsHandler.onScore -= stats.AddScore;
        GameplayEventsHandler.onScore -= UpdateScore;
        GameplayEventsHandler.onGameOver -= GameOver;

    }

    private void UpdateScore() 
    {
        scoreText.text = stats.score.ToString();
    }

    private void GameOver()
    {
        gamaOverPanel.gameObject.SetActive(true);
        highScore.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void StartGame() {

        GameplayEventsHandler.onGameStart.Invoke();

        startPanel.gameObject.SetActive(false);
    
    }

    public void PauseGame() 
    {
        GameplayEventsHandler.onGamePause.Invoke();

        pausePanel.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    public void UnPauseGame() 
    {
        GameplayEventsHandler.onGameUnPause.Invoke();

        pausePanel.gameObject.SetActive(false);

        Time.timeScale = 1;

    }

    public void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
}
