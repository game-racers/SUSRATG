using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	public static Manager instance;

	void Start()
	{
		instance = this;
	}

	public GameObject player;
	// Update is called once per frame
	void Update()
	{

	}
}
