using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    //Variáveis para reproduzir effeitos sonoros
    public GameObject EffectsPlayer;
    public AudioClip Effect0;
    public AudioClip Effect1;

    //Variáveis para reproduzir sons ambiente
    public AudioClip Track0;
    public AudioClip Track1;
    public AudioClip Track2;
    public AudioClip Track3;
    private AudioSource AudioSource;
    
    private GameObject Player;      //O jogador


    void Start () {
        AudioSource = gameObject.GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player");
        AudioSource.priority = 0;   //Prioridade do som de fundo ao máximo
    }
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<PlayerController>().GetPercentageMoved()<= 25 && !AudioSource.isPlaying)         //Dependendo da porcentagem de caminho deslocado altera qual música entra em loop
        {
            AudioSource.clip = Track0;
            AudioSource.Play();
        }
        else if(Player.GetComponent<PlayerController>().GetPercentageMoved() <= 50 && !AudioSource.isPlaying)   //50%
        {
            AudioSource.clip = Track1;
            AudioSource.Play();
        }
        else if (Player.GetComponent<PlayerController>().GetPercentageMoved() <= 75 && !AudioSource.isPlaying)  //75%
        {
            AudioSource.clip = Track2;
            AudioSource.Play();
        }
        else if (!AudioSource.isPlaying)                                                                        //100%
        {
            AudioSource.clip = Track3;
            AudioSource.Play();
        }
    }
}
