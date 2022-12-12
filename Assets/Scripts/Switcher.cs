using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{

    public GameObject[] characters;
    GameObject currentCharacter;
    int charactersIndex;
    public GameObject otherCam;
    public GameObject thisCam;
    public GameObject partner;
    public GameObject self;
    public AudioSource changeChar;

    // Start is called before the first frame update
    void Start()
    {
    //    charactersIndex = 0;
     //   currentCharacter = characters[0];
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Fire1"))
		{

            // Vector3 dest = new Vector3(currentCharacter.position.x, currentCharacter.position.y, cr.position.z);
            //  transform.position = Vector3.SmoothDamp(transform.position, dest, ref velocity, time);

            //   charactersIndex++;
            //   if(charactersIndex == characters.Length)
            //	{
            //       charactersIndex = 0;
            //	}
            //  currentCharacter.GetComponent<PlayerControl>().enabled = false;
            // characters[charactersIndex].GetComponent<PlayerControl>().enabled = true;
            //This code switches the camera to the next character in the index, NOTE obsolete, kept in for sake of reference and possible usage with more characters.
            //   GameObject.Find("Main_Camera").GetComponent<CameraController>().target = characters[charactersIndex].transform;
            //  currentCharacter = characters[charactersIndex];
            partner.GetComponent<PlayerControl>().enabled = true;
            partner.GetComponent<AI>().enabled = false;
            partner.GetComponent<Switcher>().enabled = true;
            self.GetComponent<PlayerControl>().IsMoving = false;
            self.GetComponent<PlayerControl>().enabled = false;
            self.GetComponent<AI>().enabled = false;
            self.GetComponent<Switcher>().enabled = false;
            otherCam.SetActive(true);
            thisCam.SetActive(false);
            changeChar.Play();
        }

   //     if (Input.GetButtonDown("Fire2"))
   //     {
   //         if (characters[charactersIndex].GetComponent<AI>().enabled)
			//{
   //             characters[charactersIndex].GetComponent<AI>().enabled = false;
   //         }
   //         if (characters[charactersIndex].GetComponent<AI>().enabled == false)
   //         {
   //             characters[charactersIndex].GetComponent<AI>().enabled = true;
   //         }

      //  }
    }
}
