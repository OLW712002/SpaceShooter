using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;
    float smoothSpeed = 5f;

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, playerHealth.GetHealth(), Time.deltaTime * smoothSpeed);
        scoreText.text = scoreKeeper.GetScore().ToString("D10");
    }
}
