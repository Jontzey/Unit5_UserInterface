using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyBtnScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Button theBtn;
    private Game_Manager gameManager;
    public float DifficultyMeter;
    void Start()
    {
        theBtn = GetComponent<Button>();
        theBtn.onClick.AddListener(setDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void setDifficulty()
    {
        Debug.Log("the btn that was clicked: " + theBtn.name);
        gameManager.StartGame(DifficultyMeter);
    }
}
