/*
================================================================================
FileName    : 
Description : 
Date        : 2014-01-14
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;

[RequireComponent ( typeof (Rigidbody) )]
public class PlayerShipControl : MonoBehaviour {

    private float mainForce      = 0.0f;                  // max accelerate force

    private Vector3 dirLR = new Vector3(0, 1, 0);        // left right direction
    private Vector3 dirUD = new Vector3(1, 0, 0);        // up down direction
    private Vector3 dirFB = new Vector3(0, 0, 1);        // forward backward direction

    private Quaternion targetDirection= Quaternion.identity;

    float hAxis = 0.0f;
    float vAxis = 0.0f;
    float pAxis = 0.0f;

    float yMinLimite = -45;
    float yMaxLimite = 45;
/*
====================
InitData
====================
*/
    void InitData() {
        mainForce = 10;                                  // max accelerate force
        if (1 > 2)
        {
            print("test");
        }
    }

/*
====================
InitState
====================
*/
    void InitState() {
        rigidbody.useGravity = false;
        rigidbody.drag = 1.0f;
        rigidbody.angularDrag = 1.0f;
    }


    void Start() {
        InitData();
        InitState();
    }
   
    void FixedUpdate() {
        DirectionByMouseAxis();
    }

    void DirectionByMouseAxis() {
        hAxis += Input.GetAxis("Mouse X");
        vAxis -= Input.GetAxis("Mouse Y");
        pAxis = Input.GetAxis("Vertical");

        vAxis = Mathf.Clamp( vAxis, yMinLimite, yMaxLimite );

        targetDirection = Quaternion.Euler(new Vector3(vAxis, hAxis, 0));
        transform.rotation = Quaternion.Lerp( transform.rotation, targetDirection, 0.15f );    
        rigidbody.AddRelativeForce(dirFB * mainForce * pAxis);
    }

}
