using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChanger : MonoBehaviour {

    public GameObject soundSource;
    private SoundController soundController;

    private void Start()
    {
        soundController = soundSource.GetComponent<SoundController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            soundController.addCurrentTrackNumber();
            Destroy(gameObject);
        }
    }

}
