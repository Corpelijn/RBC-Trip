using UnityEngine;
using System.Collections;

public class FAKE : MonoBehaviour {

    public GameObject bloodcell;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = bloodcell.transform.position;
	}
}
