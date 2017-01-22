﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	/// <summary>
    /// Text box to display the enemies chord
    /// </summary>
	public Text chordText;
	/// <summary>
    /// Spawn of the cord shot from the enemy.
    /// </summary>
	public GameObject chordSpawn, chordPrefab;
	/// <summary>
    /// This is the enemy cord size to damage them. Used for level difficulty in scaling. 1-3 only
    /// </summary>
	public int enemyDifficulty = 3;
	/// <summary>
    /// Shot diffculty used in level scaling.
    /// </summary>
	public int enemyShotDifficulty = 3;
	/// <summary>
    /// Enemies cord to hit them with.
    /// </summary>
	private Chord target;

	void Awake()
	{
		shoot (enemyShotDifficulty);
		setTarget();
	}

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{

	}

	/// <summary>
    /// The enemies cord to hit them with.
    /// </summary>
    /// <param name="_n">Array of notes</param>
	public void setTarget ()
	{
		target = new Chord();
		target.Initialize(Direction.None, enemyDifficulty);
		setTextBar(target.getNotes());
	}
	/// <summary>
    /// Spawn random cords with given size notes.
    /// </summary>
    /// <param name="size">Number to shoot</param>
	void shoot(int size) 
	{
		GameObject bullet = (GameObject)Instantiate(chordPrefab, chordSpawn.transform.position, new Quaternion());
		bullet.GetComponent<Chord>().randomChord (size);
	}
	/// <summary>
    /// Sets the text bar with the notes of the object
    /// </summary>
    /// <param name="_n">Notes of the player</param>
	private void setTextBar(Notes[] _n)
	{
		string o = "";
		for (int i = 0; i < _n.Length; i++)
		{
			o += _n[i].ToString() + " ";
		}
		chordText.text = o;
	}
	/// <summary>
    /// Collision handling for the Enemy and notes.
    /// </summary>
    /// <param name="col">Collider</param>
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Note")
		{
			if (this.target.notesAreEqual(col.gameObject.GetComponent<Chord>())) 
			{
				Destroy (gameObject);
			}
		}	
	}
}
