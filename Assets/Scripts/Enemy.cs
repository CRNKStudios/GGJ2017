﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Chord target;
	public GameObject chordSpawn;
	public GameObject[] chordPrefab;

	// Use this for initialization
	void Start () {
		target = new Chord ();
	}

	//Use this to set enemy target note
	void setTarget (Notes first, Notes second, Notes third)
	{
		target.Initialize (first, second, third);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Spawn random chord
	void shoot(int size) {
		//Create random chord
		Chord bullet = new Chord ();
		for (int i = 0; i < 3; i++){
			if(i >= size)
				bullet.notes[i] = Notes.Empty;
			else
				bullet.notes[i] = (Notes)Random.Range(0, 4);
		}
		bullet.setDirection(Direction.Left);
		//Spawn the chord
		Chord newBullet = (Chord) Instantiate (bullet, chordSpawn.transform);
	}
}
