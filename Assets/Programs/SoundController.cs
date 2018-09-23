using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    //Variáveis para reproduzir effeitos sonoros
    private AudioSource EffectSource;
    public GameObject EffectsPlayer;
    public AudioClip Effect0;
    public AudioClip Effect1;
    public AudioClip Effect2;

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
        EffectSource = EffectsPlayer.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("q"))
        {
            print("ola");
            PlayEffect((int)Mathf.Floor(Random.Range(0, 3)));
        }

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

    public void PlayEffect(int EffectNumber)
    {
        if(EffectNumber == 0 && !EffectSource.isPlaying)
        {
            EffectSource.clip = Effect0;
            EffectSource.Play();
        }
        else if(EffectNumber == 1 && !EffectSource.isPlaying)
        {
            EffectSource.clip = Effect1;
            EffectSource.Play();
        }
        else if(!EffectSource.isPlaying)
        {
            EffectSource.clip = Effect2;
            EffectSource.Play();
        }
    }
}
