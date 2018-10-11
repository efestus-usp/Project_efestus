using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    //Variáveis para reproduzir effeitos sonoros
    private AudioSource effectSource;
    public GameObject effectsPlayer;
    public AudioClip effect0;
    public AudioClip effect1;
    public AudioClip effect2;

    //Variáveis para reproduzir sons ambiente
    public GameObject secondSoundPlayer;
    public AudioClip track0;
    public AudioClip track1;
    public AudioClip track2;
    public AudioClip track3;
    public AudioClip track4;
    public AudioClip track5;
    public AudioClip track6;
    public AudioClip track7;
    public AudioClip track8;
    public AudioClip track9;
    private AudioClip nextTrack;
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private bool switchTracks = false;
    private bool isPlaying = false;
    private float nextTrackTimer;

    //Constantes de tempo para o fade in / fade out dos audios
    //Para o loop
    const float timerTrack0To0 = 5.22f;
    const float timerTrack1To1 = 8.2f;
    const float timerTrack2To2 = 8.2f;
    const float timerTrack3To3 = 9.55f;
    const float timerTrack4To4 = 9.36f;
    const float timerTrack5To5 = 5.82f;
    const float timerTrack6To6 = 9.96f;
    const float timerTrack7To7 = 12.83f;
    const float timerTrack8To8 = 10.51f;
    const float timerTrack9To9 = 37.6f;
    //const float timerTrack10To10 = 37.6f;

    //Para a próxima faixa
    const float timerTrack0To1 = 5.5f;
    const float timerTrack1To2 = 8.81f;
    const float timerTrack2To3 = 7.15f;
    const float timerTrack3To4 = 9.40f;
    const float timerTrack4To5 = 9.53f;
    const float timerTrack5To6 = 5.27f;
    const float timerTrack6To7 = 9.96f;
    const float timerTrack7To8 = 12.3f;
    const float timerTrack8To9 = 10.27f;

    private GameObject Player;      //O jogador


    void Start () {
        audioSource1 = gameObject.GetComponent<AudioSource>();
        audioSource2 = secondSoundPlayer.GetComponent<AudioSource>();
        Player = GameObject.FindWithTag("Player");
        audioSource1.priority = 0;   //Prioridade do som de fundo ao máximo
        effectSource = effectsPlayer.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("q"))
        {
            PlayEffect((int)Mathf.Floor(Random.Range(0, 3)));
        }

        AudioSource activeSource = wichSourceIsPlaying();

        if (Player.GetComponent<PlayerController>().getPercentageMoved()<= 25 && !isPlaying)          //Dependendo da porcentagem de caminho deslocado altera qual música entra em loop
        {
            nextTrack = track0;
            print("ola");
            StartCoroutine(timerToSwitch(timerTrack0To0));
        }
        else if(Player.GetComponent<PlayerController>().getPercentageMoved() <= 50 && !isPlaying)     //50%
        {
            print("opa");
            nextTrack = track1;
            if(activeSource.clip.Equals(nextTrack))
            {
                StartCoroutine(timerToSwitch(timerTrack1To1));
            }
            else
            {
                StartCoroutine(timerToSwitch(timerTrack0To1));
            }
            
        }
        else if (Player.GetComponent<PlayerController>().getPercentageMoved() <= 75 && !isPlaying)    //75%
        {
            nextTrack = track2;
            if (activeSource.clip.Equals(nextTrack))
            {
                StartCoroutine(timerToSwitch(timerTrack2To2));
            }
            else
            {
                StartCoroutine(timerToSwitch(timerTrack1To2));
            }
        }
        else if(!isPlaying)                                                                             //100%
        {                                                                         
            nextTrack = track3;
            if (activeSource.clip.Equals(nextTrack))
            {
                StartCoroutine(timerToSwitch(timerTrack3To3));
            }
            else
            {
                StartCoroutine(timerToSwitch(timerTrack2To3));
            }
        }
    }

    public void PlayEffect(int EffectNumber)
    {
        if(EffectNumber == 0 && !effectSource.isPlaying)
        {
            effectSource.clip = effect0;
            effectSource.Play();
        }
        else if(EffectNumber == 1 && !effectSource.isPlaying)
        {
            effectSource.clip = effect1;
            effectSource.Play();
        }
        else if(!effectSource.isPlaying)
        {
            effectSource.clip = effect2;
            effectSource.Play();
        }
    }

    IEnumerator timerToSwitch(float delay)
    {
        isPlaying = true;
        yield return new WaitForSeconds(delay);
        isPlaying = false;
        if(switchTracks)
        {
            audioSource2.clip = nextTrack;
            print("tocando source 2");
            audioSource2.Play();
            switchTracks = false;
        }
        else
        {
            print("tocando clip 1");
            audioSource1.clip = nextTrack;
            audioSource1.Play();
            switchTracks = true;
        }
    }

    public AudioSource wichSourceIsPlaying()
    {
        if(audioSource1.isPlaying)
        {
            if (audioSource2.isPlaying)
            {
                if (audioSource1.time > audioSource2.time)
                {
                    return audioSource2;
                }
                else return audioSource1;
            }
            else return audioSource1;
        }
        else if(audioSource2.isPlaying)
        {
            return audioSource2;
        }

        return null;
    }
}
