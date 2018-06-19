using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour {

    public Camera mainCam;
    private bool Activate;

    private float minSpeed;
    public float maxSpeed;
    public float currentSpeed;
    public float accelerationTime;
    private float time;

    private float screenMidPoint;

    private float minTurn;
    public float maxTurn;
    public float turnSpeed;
    public float turnStrenght;
    private float turnTime;
    
    // Use this for initialization
	void Start () {
        Activate = false;
        screenMidPoint = Screen.width / 2;

        minSpeed = currentSpeed;
        time = 0f;

        minTurn = turnSpeed;
        turnTime = 0f;
	}

    // Update is called once per frame
    void Update() {
        if (mainCam.orthographicSize > 3)
            Activate = true;

        if (Activate)
            InitializeLaunch();

        if (Activate)
            RocketController();     
    }

    void FixedUpdate()
    {
        //float yVel = this.GetComponent<Rigidbody2D>().velocity.y;
        //Debug.Log(yVel);
    }

    void InitializeLaunch()
    {
        currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
        transform.position += transform.up * currentSpeed * Time.deltaTime;
        time += Time.deltaTime;
    }

    void RocketController()
    {

        if (Input.GetAxis("Fire1") > 0f)
        {
            if (Input.mousePosition.x < screenMidPoint)
            {
                turnSpeed = Mathf.SmoothStep(minTurn, maxTurn, turnTime / turnStrenght);
                transform.position += transform.right * turnSpeed * Time.deltaTime;
            }
            else if (Input.mousePosition.x >= screenMidPoint)
            {
                turnSpeed = Mathf.SmoothStep(minTurn, maxTurn, turnTime / turnStrenght);
                transform.position -= transform.right * turnSpeed * Time.deltaTime;
            }
            turnTime += Time.deltaTime;
        }
        else
        {
            turnTime = 0.0f;
            turnSpeed = 0.0f;
        }
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
