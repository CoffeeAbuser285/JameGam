using TMPro; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // For UI elements like Text and Slider

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  
    public Slider healthBar;  
    public TextMeshProUGUI timerText;  

    private int score = 0;
    private float timeElapsed = 0f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // Initialize UI elements (if you want to set any starting text)
        UpdateScoreUI();
        UpdateHealthUI();
        UpdateTimerUI();
    }

    void Update()
    {
        // Update timer
        timeElapsed += Time.deltaTime;
        UpdateTimerUI();
        UpdateHealthUI();
    }

    // Call this method when the player earns points
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Update the UI elements with current data
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHealthUI()
    {
        healthBar.value = player.GetComponent<Health>().getCurrentHealth();  // Update the health slider value
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}