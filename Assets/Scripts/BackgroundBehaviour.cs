using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehaviour : MonoBehaviour {

    public GameObject player;
    public float ySpeed;
    public float xSpeed;

    private Renderer rend;
    private float screenMidPoint;

    private RocketBehaviour rocketScript;
    private Vector2 offset;

    // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        screenMidPoint = Screen.width / 2;
        rocketScript = player.GetComponent<RocketBehaviour>();

    }
	
	// Update is called once per frame
	void Update () {

        ySpeed = rocketScript.currentSpeed / 10000;
        xSpeed = rocketScript.turnSpeed / 10000;

        offset += new Vector2(0, Time.time * ySpeed);
        rend.material.mainTextureOffset = offset;

        if (Input.GetAxis("Fire1") > 0f)
        {
            if (Input.mousePosition.x < screenMidPoint)
            {
                offset += new Vector2(Time.time * xSpeed, 0);
            }
            else if (Input.mousePosition.x >= screenMidPoint)
            {
                offset -= new Vector2(Time.time * xSpeed, 0);
            }
            rend.material.mainTextureOffset = offset;
        }
        else
        {
            if (player.transform.position.x > 0.1f)
            {
                offset -= new Vector2(Time.time * (xSpeed / 2), 0);
            }
            else if (player.transform.position.x < -0.1f)
            {
                offset += new Vector2(Time.time * (xSpeed / 2), 0);
            }
        }
    }
}
