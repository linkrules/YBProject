/*
================================================================================
FileName    : PlayerCameraControl
Description : the player camera action
Date        : 2014-01-23
Author      : Linkrules
================================================================================
*/
using UnityEngine;
using System.Collections;
using GameTools;

public class PlayerCameraControl : MonoBehaviour {

    // view mode attribute
    private float x = 0.0f;
    private float y = 0.0f;
    private float yMinLimit = -30f;
    private float yMaxLimit = 30f;
    private float cameraMoveSpeed = 80.0f;
    private Quaternion backupRotation;
    private bool isViewMode = false;

    // follow mode attribute
    public Transform targetTransform = null;
    public float distance            = 10.0f;
    public float height              = 5.0f;
    public float heightDamping       = 2.0f;
    public float rotationDamping     = 4.0f;

	void Start () {
        GlobalManager.instance.globalGameControl.InitGameDisplay();	
        backupRotation = transform.rotation;

        if( targetTransform == null ) {
            Debug.LogError("Camera has no follow Transform!");
            Destroy(this);
        }

        CameraAsChildOfPlayer();

	}
	
	void LateUpdate () {
        //CameraFollowPlayer();
	}


/*
====================
CameraAsChildOfPlayer
====================
*/
    void CameraAsChildOfPlayer() {
        transform.position = targetTransform.position;
        //Vector3 offset = new Vector3(0, 4, -7.5f);
        transform.parent = targetTransform;
    }



/*
====================
CameraFollowPlayer
====================
*/
    void CameraFollowPlayer() {
        if( Input.GetMouseButtonDown(0) ) {
            isViewMode = true;
        }
        else if( Input.GetMouseButtonUp(0) ) {
            transform.rotation = backupRotation;
            isViewMode = false;
            x = 0;
            y = 0;
        }

        if( isViewMode ) {        // view mode
            x = Input.GetAxis("Mouse X") * Time.fixedDeltaTime * cameraMoveSpeed;
            //y = Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * cameraMoveSpeed;
            //y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
            //transform.rotation = Quaternion.Euler(y, x, 0);
            transform.RotateAround(targetTransform.position, new Vector3(0, 1, 0), x);
        }
        else {                    // follow mode
            float wantedRotationAngle = targetTransform.eulerAngles.y;
            float wantedHiehgt = targetTransform.position.y + height;

            float currentRotationAngle = transform.eulerAngles.y;
            float currentHeight = transform.position.y;

            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
            currentHeight = Mathf.Lerp(currentHeight, wantedHiehgt, heightDamping * Time.deltaTime);

            Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            transform.position = targetTransform.position;
            transform.position -= currentRotation * Vector3.forward * distance;
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        }
        transform.LookAt(targetTransform);
    }

    void CameraFollowPlayerVersion2() {

    }

}
