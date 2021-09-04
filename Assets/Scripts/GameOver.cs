using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject onScreenScore;
    public Text score;
    public Text currentScore;
    bool gameOver;

    private void Start()
    {
        FindObjectOfType<movement>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        if (gameOver)
        {
            onScreenScore.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    
    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        score.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
