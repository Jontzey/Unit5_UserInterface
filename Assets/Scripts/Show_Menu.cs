using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Menu : MonoBehaviour
{
    public Game_Manager manager;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<Game_Manager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.isGameOver == true)
        {
            menu.SetActive(true);
        }
    }
}
