using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float IniAngle;
    private float Counter;
    private float CurrentSpeed;
    private CharacterController Controller;
    private bool SeenFriend;
    public GameObject Camera;
    public float Timer;
    public float Speed;
    public float FriendCounter;
    public float Range;

	// Use this for initialization
	void Start () {
        Controller = gameObject.GetComponent<CharacterController>();
        SeenFriend = false;
        CurrentSpeed = Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!SeenFriend)
        {
            Collider[] ColliderList;
            ColliderList = Physics.OverlapSphere(gameObject.transform.position, Range);
            foreach (Collider element in ColliderList)
            {
                if (element.gameObject.tag == "Friend")
                {
                    IniAngle = Camera.GetComponent<Light>().spotAngle;
                    SeenFriend = true;
                    FriendCounter++;
                    Counter = Time.time;
                }
            }
        }
        else if(Counter + Timer > Time.time)
        {
            Camera.GetComponent<Light>().spotAngle += Time.deltaTime * IniAngle / (Timer * 8);
            CurrentSpeed = 0;
        }
        else
        {
            CurrentSpeed = Speed;
            SeenFriend = false;
        }

        Controller.Move(gameObject.transform.forward * CurrentSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        Controller.Move(gameObject.transform.right * CurrentSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
