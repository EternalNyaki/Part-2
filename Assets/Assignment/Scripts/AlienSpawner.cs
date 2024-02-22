using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlienSpawner : MonoBehaviour
{
    public float spawnInterval;

    public TextMeshProUGUI scoreText;
    public GameObject alienPrefab;

    private float timer;
    private int score = 0;

    private void Start()
    {
        transform.position = Vector3.zero;

        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnInterval)
        {
            timer -= spawnInterval;

            Instantiate(alienPrefab, transform);
        }

        timer += Time.deltaTime;
    }

    public void IncreaseScore()
    {
        score++;

        PlayerPrefs.SetInt("Score", score);
        if(score > PlayerPrefs.GetInt("High Score"))
        {
            PlayerPrefs.SetInt("High Score", score);
        }

        if(scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
