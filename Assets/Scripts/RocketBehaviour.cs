using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour {

    public Camera mainCam;

    public float maxSpeed;
    public float currentSpeed;
    public float accelerationTime;

    private bool Activate;
    private float minSpeed;
    private float time;
    
    // Use this for initialization
	void Start () {
        Activate = false;

        minSpeed = currentSpeed;
        time = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (mainCam.orthographicSize > 3)
            Activate = true;

        if (Activate)
            InitializeLaunch();

	}

    void InitializeLaunch()
    {
        currentSpeed = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
        transform.position += transform.up * currentSpeed * Time.deltaTime;
        time += Time.deltaTime;
    }
}
