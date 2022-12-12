using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public Transform target; //the player
    public float moveSpeed = 2.0f;
    public float radius = 3.0f;

    Animator m_Animator;
    private Vector3 location;

    void Start()
	{
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Look at the target
        //transform.LookAt(target);
        location = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        transform.LookAt(location);

        if (Vector3.Distance(target.position, transform.position) < radius)
        {
            moveSpeed = 0;
            m_Animator.SetBool("IsWalking", false);

        }

        if (Vector3.Distance(target.position, transform.position) > radius)
        {
            moveSpeed = 5.0f;
            m_Animator.SetBool("IsWalking", true);
        }

        //Move towards the target
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);



    }
}
