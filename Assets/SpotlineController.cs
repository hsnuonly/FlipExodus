using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlineController : MonoBehaviour {
    // Use this for initialization
    public PlayerController playerController;
    int direction = 0;
    const int down = 0;
    const int up = 1;
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log(transform.eulerAngles);
        if (playerController.direction == 1)
        {
            if (this.transform.rotation.x >= 0) direction = up;
            else if (this.transform.rotation.x <= -0.75) direction = down;
            if (direction == down) this.transform.Rotate(new Vector3(1, 0, 0));
            else this.transform.Rotate(new Vector3(-1, 0, 0));
        }
        else
        {
            if (this.transform.rotation.z >= 0) direction = up;
            else if (this.transform.rotation.z <= -0.75) direction = down;
            if (direction == down) this.transform.Rotate(new Vector3(0, 0, 1));
            else this.transform.Rotate(new Vector3(0, 0, -1));
        }
	}
}
