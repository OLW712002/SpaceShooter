using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Slider healthSlider;
    [SerializeField] float smoothSpeed = 5f;
    [SerializeField] TextMeshProUGUI scoreText;

    Health playerHealth;
    int healthAtStart;

    ScoreKeeper scoreKeeper;

    private void Start()
    {
        playerHealth = player.GetComponent<Health>();
        healthAtStart = playerHealth.GetHealth();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update()
    {
        float percentHealth = (float)playerHealth.GetHealth() / (float)healthAtStart;
        healthSlider.value = Mathf.Lerp(healthSlider.value, percentHealth, Time.deltaTime * smoothSpeed);
        scoreText.text = scoreKeeper.GetScore().ToString("D10");
    }
}
