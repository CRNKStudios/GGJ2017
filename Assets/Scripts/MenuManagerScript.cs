using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

    public Text finalScore;
    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "start_menu"
        || SceneManager.GetActiveScene().name == "instructions"
        || SceneManager.GetActiveScene().name == "credits"
        || SceneManager.GetActiveScene().name == "game_over")
        {
            this.GetComponent<AudioSource>().Play();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "game_over")
        {
            updateScore();
        }
	}

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void changeScene(int s)
    {
        SceneManager.LoadScene(s);
    }

    public void startGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("score", 0);
    }

    public void exitGame()
    {
         Application.Quit();
    }

    private void updateScore()
    {
        finalScore.text = "" + PlayerPrefs.GetInt("level");
    }
}
