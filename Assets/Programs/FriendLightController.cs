using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendLightController : MonoBehaviour {

    private GameObject Player;
    public bool FadeOutBool;
    private float Counter;
    private float IntialIntensity;
    public float Range;
    public float Timer;

    void Start () {
        Player = GameObject.FindWithTag("Player");
        FadeOutBool = true;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit Hit;
        gameObject.transform.LookAt(Player.transform);
        if (FadeOutBool && Physics.Raycast(gameObject.transform.position,transform.forward, out Hit, Range))
        {
           Debug.DrawLine(gameObject.transform.position, Hit.point);
           if(Hit.collider.tag == "Player")
            {
                FadeOutBool = false;
                Counter = Time.time;
                IntialIntensity = gameObject.GetComponent<Light>().intensity;
            }
        }

        if(!FadeOutBool)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.clear, Time.time / (Counter + Timer));
            gameObject.GetComponent<Light>().intensity -= Time.deltaTime * IntialIntensity / Timer;
            if(Counter + Timer < Time.time)
            {
                Destroy(gameObject);
            }
        }
	}


}
