using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            SceneManager.LoadScene(0);
        }
    }
}
