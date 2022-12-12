using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
	{
        //Lose Condition True
        if (col.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene("Lose Screen");
            Cursor.visible = true;
        }
	}



}
