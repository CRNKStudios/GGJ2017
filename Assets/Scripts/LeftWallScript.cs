using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallScript : MonoBehaviour {
    public GameObject nms;
    private MenuManagerScript endGame;

	// Use this for initialization
	void Start () {
        endGame = nms.GetComponent<MenuManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Note")
        {
            endGame.changeScene("game_over");
        }
    }
}
