using UnityEngine;
using System.Collections;

public class OxygenController : MonoBehaviour {

    public bool hasOxygen;

	// Use this for initialization
	void Start () 
    {
        hasOxygen = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Oxygen")
        {
            if (col.name == "DropOffPoint" && hasOxygen == true)
            {
                hasOxygen = false;
                //Change color to blue (Without Oxygen)
                Debug.Log("Lost Oxygen");
            }
            if (col.name == "ObtainPoint" && hasOxygen == false)
            {
                hasOxygen = true;
                //Change color to red (With Oxygen)
                Debug.Log("Obtained Oxygen");
            }
        }
    }
}
