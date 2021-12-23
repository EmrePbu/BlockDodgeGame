using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using scene management in unity engine
using UnityEngine.SceneManagement;
// using the textmeshpro component
using TMPro;

public class GameManager : MonoBehaviour
{
    // total score float  
    public float totalScore = 0;
    // tmp score text
    public TextMeshProUGUI tmpScore;
    // slowness 10f
    public float slowness = 10;

    // public method endGame
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }
    // add score to the player
    public void AddScore(float score)
    {
        // add score to the total score
        totalScore += score;
        // set the text of the tmp score to the total score
        tmpScore.text = totalScore.ToString();
    }
    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        // scene maganer load scene GameoverScene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameoverScene");
    }
}
