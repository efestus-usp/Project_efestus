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
    private int currentTrackNumber;

    //Constantes de tempo para o fade in / fade out dos audios
    //Para o loop
    const float timerTrack0To0 = 5.22f; //75
    const float timerTrack1To1 = 8.2f;  //75
    const float timerTrack2To2 = 7.1f;  //75
    const float timerTrack3To3 = 9.55f; //50
    const float timerTrack4To4 = 9.36f; //50
    const float timerTrack5To5 = 5.82f; //75
    const float timerTrack6To6 = 9.96f; //50
    const float timerTrack7To7 = 12.83f;//63
    const float timerTrack8To8 = 10.51f;//52
    const float timerTrack9To9 = 37.6f;//210
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
        currentTrackNumber = -1;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("q"))
        {
            PlayEffect((int)Mathf.Floor(Random.Range(0, 3)));
        }

        AudioSource activeSource = wichSourceIsPlaying();

        if(!isPlaying)
        {
            print("Tocando " + currentTrackNumber);
            switch (currentTrackNumber)
            {
                case 0:
                    if(audioSource1.clip == null)
                    {
                        audioSource1.clip = track0;
                        audioSource1.Play();
                    }
                    nextTrack = track0;
                    StartCoroutine(timerToSwitch(timerTrack0To0));
                    print("Tocando " + currentTrackNumber);
                    break;

                case 1:
                    nextTrack = track1;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack1To1));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack0To1));
                    }
                    break;

                case 2:
                    nextTrack = track2;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack2To2));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack1To2));
                    }
                    break;

                case 3:
                    nextTrack = track3;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack3To3));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack2To3));
                    }
                    break;

                case 4:
                    nextTrack = track4;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack4To4));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack3To4));
                    }
                    break;

                case 5:
                    nextTrack = track5;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack5To5));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack4To5));
                    }
                    break;

                case 6:
                    nextTrack = track6;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack6To6));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack5To6));
                    }
                    break;

                case 7:
                    nextTrack = track7;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack7To7));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack6To7));
                    }
                    break;

                case 8:
                    nextTrack = track8;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack8To8));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack7To8));
                    }
                    break;

                case 9:
                    print("Ola");
                    nextTrack = track9;
                    if (activeSource.clip.Equals(nextTrack))
                    {
                        StartCoroutine(timerToSwitch(timerTrack9To9));
                    }
                    else
                    {
                        StartCoroutine(timerToSwitch(timerTrack8To9));
                    }
                    break;
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
            audioSource2.Play();
            switchTracks = false;
        }
        else
        {
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

    public void addCurrentTrackNumber()
    {
        currentTrackNumber++;
    }
}
