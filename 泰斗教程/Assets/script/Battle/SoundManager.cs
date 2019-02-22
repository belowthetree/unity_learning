using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    public AudioClip[] audioClipArray;
    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
    public AudioSource AudioSource;
    public bool isQuiet = false;

    void Start()
    {
        foreach(AudioClip ac in audioClipArray)
        {
            audioDict.Add(ac.name, ac);
        }
    }

	void Awake () {
        instance = this;
	}

	public void Play(string audioName)
    {
        if (isQuiet)
            return;
        AudioClip ac;
        if (audioDict.TryGetValue(audioName, out ac))
        {
            //AudioSource.PlayClipAtPoint(ac, Vector3.zero);
            AudioSource.PlayOneShot(ac);
        }
    }

    public void Play(string audioName, AudioSource audioSource)
    {
        if (isQuiet)
            return;
        AudioClip ac;
        if (audioDict.TryGetValue(audioName, out ac))
        {
            //AudioSource.PlayClipAtPoint(ac, Vector3.zero);
            audioSource.PlayOneShot(ac);
        }
    }
}
