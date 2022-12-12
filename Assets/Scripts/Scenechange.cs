using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenechange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void ToSceneOne()
    {
        SceneManager.LoadScene("Level_1 (Easy)");
    }

    public void ToSceneTwo()
    {
        SceneManager.LoadScene("Level_2 (Medium)");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Stop()
    {
        Application.Quit();
    }
}
