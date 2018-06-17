using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public GameObject mPlayer;

    private float min = 2.0f;
    private float max = 5.0f;

    private float sValue = 0.0f;
    private Vector2 offset;

    private bool Begun;
    Camera m_mainCam;

	// Use this for initialization
	void Start () {
		m_mainCam = this.GetComponent<Camera>();
        Begun = false;

        offset = transform.position - mPlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Begun)
        {
            Begun = true;
        }

        PlayTransition();

        if (Begun)
        {
            transform.position = new Vector3(mPlayer.transform.position.x,
                Mathf.Lerp(mPlayer.transform.position.y, mPlayer.transform.position.y + 3.0f, sValue), -10f);
        }
    }

    void PlayTransition()
    {
        if (Begun)
        {
            m_mainCam.orthographicSize = Mathf.Lerp(min, max, sValue);
            sValue += 0.2f * Time.deltaTime;
        }
    }
}
