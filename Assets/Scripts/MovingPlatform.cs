using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 1.0f;

    private float startTime;
    private float journeyLength;
    private Vector3 velocity;
	
    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
		{
            col.transform.parent = this.transform;
            Debug.Log("Parented");
            //col.transform.position += new Vector3(speed, 0f, 0f);
        }
	}

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
            Debug.Log("De-Parented");
        }
    }

    void FixedUpdate()
    {
        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);

        if (fractionOfJourney >= .999)
        {
            startTime = Time.time;
            Transform temp = startMarker;
            startMarker = endMarker;
            endMarker = temp;
        }
    }
}
