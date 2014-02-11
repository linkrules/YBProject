using UnityEngine;
using System.Collections;

public class WeaponSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if( Input.GetKeyDown(KeyCode.Space) ) {
            NotificationCenter.DefaultCenter.PostNotification(this, "OpenLaser");
        }

        if( Input.GetKeyUp(KeyCode.Space) ) {
            NotificationCenter.DefaultCenter.PostNotification(this, "CloseLaser");
        }
	
	}
}
