using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    //public GameObject[] obstacles;
    public GameObject wall;


    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Interactable") == null)
        {
            Destroy(wall);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Lose Condition True
        SceneManager.LoadScene("Win Screen");
    }
}
