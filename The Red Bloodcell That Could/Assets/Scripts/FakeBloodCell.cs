using UnityEngine;
using System.Collections;

public class FakeBloodCell : MonoBehaviour {

    public GameObject bloedcel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = bloedcel.transform.position;
	}
}
