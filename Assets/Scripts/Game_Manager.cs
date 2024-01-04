using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public float spawnRate = 1;
    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
    
        
    
}
