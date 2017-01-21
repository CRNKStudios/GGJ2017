﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public GameObject[] lanes;
	public GameObject chordSpawn, chordPrefab;
	private int location =  0, setNote = 0;
	private Notes[] input = new Notes[3];
	private Chord bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up")) {
			moveUp ();
		} else if(Input.GetKeyDown("down")){
			moveDown ();
		}

		if (setNote <= 2) {
			if (Input.GetKeyDown ("a")) {
				input [setNote] = Notes.A;
				Debug.Log (input [setNote]);
				setNote++;
			}
			if (Input.GetKeyDown ("s")) {
				input [setNote] = Notes.S;
				Debug.Log (input [setNote]);
				setNote++;
			}
			if (Input.GetKeyDown ("d")) {
				input [setNote] = Notes.D;
				Debug.Log (input [setNote]);
				setNote++;
			}
			if (Input.GetKeyDown ("f")) {
				input [setNote] = Notes.F;
				Debug.Log (input [setNote]);
				setNote++;
			}
			if (Input.GetKeyDown ("g")) {
				input [setNote] = Notes.G;
				Debug.Log (input [setNote]);
				setNote++;
			}
		}

		if (Input.GetKeyDown ("space")) {
			while (setNote <= 2) {
				input [setNote++] = Notes.Empty;
			}
			shoot ();
			Debug.Log ("Chord Fired: " + input[0] + " " + input[1] + " " + input[2]);
			setNote = 0;
		}
			
	}

	//Move player up
	void moveUp(){
		if(location > 0)
			transform.position = lanes [--location].transform.position;
	}

	//Move player down
	void moveDown(){
		if(location < lanes.Length - 1)
			transform.position = lanes [++location].transform.position;
	}

	//Shoot played chord
	void shoot(){
		GameObject bullet = (GameObject)Instantiate(chordPrefab, chordSpawn.transform.position, new Quaternion());
		bullet.GetComponent<Chord>().Initialize (input[0], input[1], input[2], Direction.Right);
	}
}
