using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	//Default Speeds
	public GameObject partner;
	public float turnSpeed = 20f;
	public float speed = 10f;
	public float jumpSpeed = 10f;
	//public bool isGrounded;


	public AudioSource come;
	public AudioSource stay;

	Animator m_Animator;
	Rigidbody m_Rigidbody;
	public Vector3 m_Movement = Vector3.zero;
	Quaternion m_Rotation = Quaternion.identity;
	//Transform target;
	private bool isGrounded = true;
	public bool IsMoving;

	// Start is called before the first frame update
	void Start()
	{
		//instantiate these
		m_Animator = GetComponent<Animator>();
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	//Detect if player character is on the ground, if so, set bool
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == ("Ground") && isGrounded == false)
		{
			isGrounded = true;
		}
	}

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		m_Movement.Set(horizontal, 0f, vertical);
		m_Movement.Normalize();

		bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
		bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

		//IsWalking true if player is moving vertically or horizontally
		IsMoving = hasHorizontalInput || hasVerticalInput;

        if (IsMoving)
		{
			m_Animator.SetBool("IsWalking", true);
		}
		else
		{
			m_Animator.SetBool("IsWalking", false);
		}

		if (isGrounded)
        {
			m_Animator.SetBool("IsGrounded", true);
        }
		else
        {
			m_Animator.SetBool("IsGrounded", false);
		}

		Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
		m_Rotation = Quaternion.LookRotation(desiredForward);


		if (Input.GetButtonDown("Fire2"))
		{
			if (partner.GetComponent<AI>().enabled ==true)
			{
				stay.Play();
				partner.GetComponent<AI>().enabled = false;
				partner.GetComponent<Animator>().SetBool("IsWalking", false);
				//Debug.Log("AI Disabled");
			}
			else
			{
				//Debug.Log("AI Enabled");
				come.Play();
				partner.GetComponent<AI>().enabled = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			m_Rigidbody.AddForce(new Vector3(0, 2, 0) * jumpSpeed, ForceMode.Impulse);
			isGrounded = false;
		}
	}

	void OnAnimatorMove()
	{
		//Rotate player character according to direction of movement
		m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * (speed + 1) * Time.fixedDeltaTime);
		transform.position += (m_Movement * (speed + 1) * Time.fixedDeltaTime);
		m_Rigidbody.MoveRotation(m_Rotation);
		//transform.position = (m_Rigidbody.position + m_Movement * (speed + 1) * Time.fixedDeltaTime);
		//transform.rotation = (m_Rotation);
	}
}
