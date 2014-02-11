using UnityEngine;
using System.Collections;

public class SmashElement : MonoBehaviour {

    private Vector3 randDirection;
    private Vector3 randRotation;
    private Vector3 sourcePos;
    private float smashTime;
    private float lifeTime = 1.0f;
    private float   randForce;
    private float   randTorque;
    private float   deathDistance = 10;
    private bool    isBeSmash = false;

    void BeSmash() {
        if( isBeSmash ) {
            return;
        }

        randDirection = new Vector3(Random.Range(-1,1.1f), Random.Range(-1,1.1f), Random.Range(-1,1.1f));
        randRotation = new Vector3(Random.value, Random.value, Random.value);
        randForce = Random.Range(2, 3);
        randTorque = randForce ;/// 4;

        Debug.Log("randDirection: " + randDirection);
        Debug.Log("randRotation : " + randRotation);
        Debug.Log("randForce    : " + randForce);
        Debug.Log("randTorque   : " + randTorque);


        smashTime = Time.time;
        isBeSmash = true;
    }


    void Start() {
        NotificationCenter.DefaultCenter.AddObserver(this, "BeSmash");
        sourcePos = transform.position;
    }



    void Update() {
        if( !isBeSmash ) {
            return;
        }

        transform.Translate(randDirection * randForce,Space.World);
        transform.Rotate(randRotation * randTorque,Space.Self);
        /*
        if( Time.time - smashTime >= lifeTime ) {
            Destroy(gameObject);
        }
         */
        
        if( Vector3.Distance(sourcePos, transform.position) > deathDistance ) {
            Destroy(gameObject);
        }
        



    }

}
