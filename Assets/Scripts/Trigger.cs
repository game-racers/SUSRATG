using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject new_object;
    public GameObject destroy;

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Wham.");
        //Change Object State
        if (col.gameObject.tag == ("Interactable"))
        {
            Instantiate(new_object, new Vector3 (col.transform.position.x, col.transform.position.y - 4f, col.transform.position.z), col.transform.rotation);
            Destroy(col.gameObject);
            Destroy(destroy);
            // Debug.Log("Bam");
        }
    }
}
