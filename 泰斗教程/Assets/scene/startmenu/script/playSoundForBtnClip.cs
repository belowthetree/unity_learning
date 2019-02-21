using UnityEngine;
using System.Collections;

public class playSoundForBtnClip : MonoBehaviour {

	public AudioSource music;
	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void playSound(){
		music.Play ();
	}
}
