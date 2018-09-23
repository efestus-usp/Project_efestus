using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float PercentageMoved;
    private float IniAngle;
    private float Counter;
    private float CurrentSpeed;
    private CharacterController Controller;
    private bool SeenFriend;
    public GameObject Light;
    public GameObject Camera;
    public float Timer;
    public float Speed;
    public float FriendCounter;
    public float Range;
    public float Xlimite;
    public float Zlimite;

	// Use this for initialization
	void Start () {
        Controller = gameObject.GetComponent<CharacterController>();
        SeenFriend = false;
        CurrentSpeed = Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float Teste = GetPercentageMoved();
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, -Xlimite, Xlimite), gameObject.transform.position.y, Mathf.Clamp(gameObject.transform.position.z, -Zlimite, Zlimite));
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, gameObject.transform.position.z);
        if(!SeenFriend)
        {
            Collider[] ColliderList;
            ColliderList = Physics.OverlapSphere(gameObject.transform.position, Range);
            foreach (Collider element in ColliderList)
            {
                if (element.gameObject.tag == "Friend")
                {
                    IniAngle = Light.GetComponent<Light>().spotAngle;
                    SeenFriend = true;
                    FriendCounter++;
                    Counter = Time.time;
                }
            }
        }
        else if(Counter + Timer > Time.time)
        {
            Light.GetComponent<Light>().spotAngle += Time.deltaTime * IniAngle / (Timer * 8);
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

    public float GetPercentageMoved()
    {
        PercentageMoved = (gameObject.transform.position.z + Zlimite) / (2 * Zlimite) *100;
        return PercentageMoved;
    }
}
