using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private bool gameOver;
    private bool restart;
    
    public Text restartText;
    public Text gameOverText;
    public Text ScoreText;
    public Text winText;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'SPACE BAR' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You win! Game Created by Nathaniel Green.";
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver()
    {
        if (score >= 100)
        {
            winText.text = "You win! Game Created by Nathaniel Green.";
            gameOver = true;
            restart = true;
        }
        else
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }

}