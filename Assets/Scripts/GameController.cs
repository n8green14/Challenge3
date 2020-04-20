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

    private BGScroller bgScroller;
    public bool bgWinScroller;
    private SFScroller sfScroller;
    public bool sfWinScroller;
    private SFScrollerDistant sfScrollerDistant;
    public bool sfWinScrollerDistant;

    

    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioClip musicClipThree;

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

        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClipOne;
        musicSource.volume = 0.5f;
        musicSource.Play();

        //find BGScroller
        GameObject bgScrollerObject = GameObject.FindWithTag("BGScroller");
        if (bgScrollerObject != null)
        {
            bgScroller = bgScrollerObject.GetComponent<BGScroller>();
        }
        if (bgScroller == null)
        {
            Debug.Log("Cannot find 'BGScroller' script");
        }
        //find SFScroller
        GameObject sfScrollerObject = GameObject.FindWithTag("SFScroller");
        if (sfScrollerObject != null)
        {
            sfScroller = sfScrollerObject.GetComponent<SFScroller>();
        }
        if (sfScroller == null)
        {
            Debug.Log("Cannot find 'SFScroller' script");
        }
        //find SFScrollerDistant
        GameObject sfScrollerDistantObject = GameObject.FindWithTag("SFScrollerDistant");
        if (sfScrollerDistantObject != null)
        {
            sfScrollerDistant = sfScrollerDistantObject.GetComponent<SFScrollerDistant>();
        }
        if (sfScrollerDistant == null)
        {
            Debug.Log("Cannot find 'SFScrollerDistant' script");
        }
        
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
        if (score >= 300)
        {
            winText.text = "You win! Game Created by Nathaniel Green.";
            musicSource.clip = musicClipThree;
            musicSource.volume = 0.45f;
            musicSource.Play();
            bgWinScroller = true;
            bgScroller.WinScroller(bgWinScroller);
            sfWinScroller = true;
            sfScroller.WinScroller(sfWinScroller);
            sfWinScrollerDistant = true;
            sfScrollerDistant.WinScroller(sfWinScrollerDistant);
            gameOver = true;
            restart = true;
            
        }
    }

    public void GameOver()
    {
        if (score >= 300)
        {
            winText.text = "You win! Game Created by Nathaniel Green.";
            gameOver = true;
            restart = true;
        }
        else
        gameOverText.text = "Game Over!";
        musicSource.clip = musicClipTwo;
        musicSource.volume = 0.6f;
        musicSource.Play();
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