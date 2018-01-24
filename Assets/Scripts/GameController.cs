using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text textScore;
    public bool gameOver = false;
    public int score = 0;

    private ColumnSpawner colSpawner;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        colSpawner = GetComponent<ColumnSpawner>();
    }

    public void IncreaseScore()
    {
        score++;
        textScore.text = string.Concat("Score: ", score);
        if(score % 5 == 0) // increase column speed
        {
            colSpawner.columnSpeed += 0.25f;
            if(colSpawner.spawnTime > 0.5f)
                colSpawner.spawnTime -= 0.5f;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
