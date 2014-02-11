using UnityEngine;
using System.Collections;

public class LaserSwitch : MonoBehaviour {

    LineRenderer lr;

    void Start() {
        NotificationCenter.DefaultCenter.AddObserver(this, "OpenLaser");
        NotificationCenter.DefaultCenter.AddObserver(this, "CloseLaser");
        lr = GetComponent<LineRenderer>();
    }

    void OpenLaser() {
        lr.enabled = true;
    }

    void CloseLaser() {
        lr.enabled = false;
    }
}
