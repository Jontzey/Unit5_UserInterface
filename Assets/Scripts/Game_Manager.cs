using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public float spawnRate = 1;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject RestartBtn;
    public bool isGameOver;
    public GameObject gameTitle;
    public List<GameObject> menuButtons;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
            RestartBtn.SetActive(true);
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameOver == false)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, gameObjects.Count);
            Instantiate(gameObjects[index]);
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
                scoreText.text = "Score: " + score;
    }
    
      public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    
    public void StartGame(float DifficultyValue)
    {
        spawnRate -= DifficultyValue;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        gameTitle.gameObject.SetActive(false);
        foreach(GameObject gameObject in menuButtons)
        {
            gameObject.gameObject.SetActive(false);
        }
    }
}
