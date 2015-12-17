using UnityEngine;
using System.Collections;

public class BloedcelRot : MonoBehaviour {

    private float random1;
    private float random2;
    private float random3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        random1 = Random.Range(15, 30);
        random2 = Random.Range(15, 30);
        random3 = Random.Range(15, 30);
        transform.Rotate(new Vector3(random1, random2, random3) * Time.deltaTime);
    }
}
