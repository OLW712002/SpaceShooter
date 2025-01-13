using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delayForResult = 2f;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        if (scoreKeeper != null) scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadResult()
    {
        StartCoroutine(WaitBeforeLoadScene("Result", delayForResult));
    }

    public void QuitGame()
    {
        Debug.Log("QuittingGame...");
        Application.Quit();
    }

    IEnumerator WaitBeforeLoadScene(string sceneName, float waitingTime)
    {
        yield return new WaitForSecondsRealtime(waitingTime);
        SceneManager.LoadScene(sceneName);
    }
}
