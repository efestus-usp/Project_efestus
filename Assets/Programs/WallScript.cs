using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public float FriendsNumber;
	
	// Update is called once per frame
	void Update () {
		if(GameObject.FindWithTag("Player").GetComponent<PlayerController>().FriendCounter >= FriendsNumber)
        {
            Destroy(gameObject);
        }
	}
}
