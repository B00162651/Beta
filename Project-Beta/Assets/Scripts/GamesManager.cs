using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GamesManager : MonoBehaviour
{
    // difiiculty for spawn
    public int difficulty;
    public TextMeshProUGUI gameOverText;
 // turns off homescreen
    public GameObject titleScreen;

    public TextMeshProUGUI scoreText;
    private int score;

    public Button restartButton;

    public SpawnManager spawnManager;

    public bool isGameActive;

    private AudioSource crashSound;
    public AudioClip playerCrash;


    // Start is called before the first frame update
    void Start()
    {
        // standard difficulty (easy)
        difficulty = 1;
    }
    // sets new difficulty when clicked by user as we have the standard diff set 
    public void SetDifficulty(int newDifficulty){
        difficulty = newDifficulty;
    }

public void StartGame(int difficulty)
{
    // Set game to active and hide the title screen
    isGameActive = true;
    titleScreen.SetActive(false);

    // Reset score and other UI elements
    
    score = 0;
    UpdateScore(0);
    scoreText.text = "Score: " + score;
    scoreText.gameObject.SetActive(true);
    // use audio source
    crashSound = GetComponent<AudioSource>();
    // spawn manager then sets the spawn rate 
    spawnManager.SetDifficulty(difficulty);

    // Start car spawning after the delay
    spawnManager.StartSpawning();
    
    

}

    // Update is called once per frame
    void Update()
    {
        
    }
    // method to update the score 
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

public void GameOver()
{
    Debug.Log("Game Over!");
    crashSound.PlayOneShot(playerCrash, 1.0f);
      // couritine to allow the delay  unit 4 
    StartCoroutine(Delay());
}

private IEnumerator Delay()
{
    // Waits 3 seconds
    yield return new WaitForSeconds(1);

    // sets menu and pauses 
    Time.timeScale = 0;  
    gameOverText.gameObject.SetActive(true); 
    restartButton.gameObject.SetActive(true);
}

public void RestartGame(){
    // restart the game
    Time.timeScale = 1; // unpause 
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   
}
}
