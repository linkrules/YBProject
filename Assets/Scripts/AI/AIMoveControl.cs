using UnityEngine;
using System.Collections;

public class AIMoveControl : MonoBehaviour {

    // attack
    public Transform attackTarget = null;
    public Vector2 attackRange   = Vector2.zero;
    public Vector2 attackRateRange    = Vector2.zero;
    public Vector2 changePosRateRange = Vector2.zero;

    // ship attribute
    public int iID = 0;
    public float aiLife = 0;
    public float aiDefense = 0;
     
    private bool isFreeMode = false;

    private float attackDistant = 0.0f;
    private float attackDirection = 0.0f;
    private float attackRate = 0.0f;
    private float changePosRate = 0.0f;

    private Vector3 myPosition = Vector3.zero;



    void InitAIData() {
        attackTarget = GameObject.FindGameObjectWithTag( "Player" ).transform;
        if( attackTarget == null ) {
            isFreeMode = true;
        }

        attackDistant = Random.Range( attackRange.x, attackRange.y );
        attackDirection = Random.Range( 0, 360 );
        attackRate = Random.Range( attackRateRange.x, attackRateRange.y );
        changePosRate = Random.Range( changePosRateRange.x, changePosRateRange.y );

        myPosition = new Vector3( Random.Range( attackRange.x, attackRange.y ), Random.Range( attackRange.x, attackRange.y ), attackDistant );
    }

    void BeAttack() {

    }

    void Start() {
        InitAIData();
    }

    void FixedUpdate() {
        transform.position = Vector3.Lerp( transform.position, myPosition, 0.5f );
        transform.LookAt( attackTarget );

    }



}
