using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GamesManager gamesManager; // reference the game manager script 
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gamesManager = GameObject.Find("GamesManager"). GetComponent<GamesManager>();// gets the game manager 
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty(){
        Debug.Log(gameObject.name + "was clicked");// know what button was clicked 
        gamesManager.SetDifficulty(difficulty);
        // starts the game 
        gamesManager.StartGame(difficulty);

    }
}
