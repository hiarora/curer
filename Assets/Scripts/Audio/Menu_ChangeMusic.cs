using UnityEngine;
using System.Collections;

public class Menu_ChangeMusic : MonoBehaviour {
	public AudioClip walkingMusic;
	private AudioSource source;
	
	void Awake () {
		source = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level) {
		if(level == 3 || level == 4) {
			source.clip = walkingMusic;
			source.Play();
		}
	}
}
