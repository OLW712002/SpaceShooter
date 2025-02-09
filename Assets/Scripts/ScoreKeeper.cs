using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    bool maxScore = false;
    static ScoreKeeper instance;

    private void Awake()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public long GetScore()
    {
        Mathf.Clamp(score, 0, 99999999);
        if (maxScore) return 9999999999;
        return (long)score*100;
    }

    public void AddScore(int value)
    {
        score += value/100;
        if (score > 99999999) maxScore = true;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
