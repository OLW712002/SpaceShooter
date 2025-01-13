using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIResult : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        scoreText.text = "Score: " + scoreKeeper.GetScore().ToString("D10");
    }
}
