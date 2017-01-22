using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tambourine : MonoBehaviour {

	/// <summary>
	/// Array of audio sources used to play sound.
	/// </summary>
	public AudioClip[] Clips;
	/// <summary>
	/// Array of audio sources used to play sound.
	/// </summary>
	private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		audioSources = new AudioSource[Clips.Length];
		int i = 0;
		while (i < Clips.Length){
			audioSources[i] = gameObject.AddComponent<AudioSource>();
			audioSources[i].clip = Clips[i];
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public AudioSource getRandomSource()
	{
		return audioSources[Random.Range(0, audioSources.Length - 1)];
	}
}
