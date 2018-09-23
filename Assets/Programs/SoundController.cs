using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioClip Track0;
    public AudioClip Track1;
    public AudioClip Track2;
    public AudioClip Track3;
    private AudioSource AudioSource;
    private GameObject Player;


    void Start () {
        AudioSource = gameObject.GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<PlayerController>().GetPercentageMoved()<= 25 && !AudioSource.isPlaying)
        {
            AudioSource.clip = Track0;
            AudioSource.Play();
        }
        else if(Player.GetComponent<PlayerController>().GetPercentageMoved() <= 50 && !AudioSource.isPlaying)
        {
            AudioSource.clip = Track1;
            AudioSource.Play();
        }
        else if (Player.GetComponent<PlayerController>().GetPercentageMoved() <= 75 && !AudioSource.isPlaying)
        {
            AudioSource.clip = Track2;
            AudioSource.Play();
        }
        else if (!AudioSource.isPlaying)
        {
            AudioSource.clip = Track3;
            AudioSource.Play();
        }
    }
}
