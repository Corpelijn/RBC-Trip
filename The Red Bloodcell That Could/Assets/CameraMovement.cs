using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public float movespeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float vertTranslation = Input.GetAxis("Vertical") * movespeed;
        float horTranslation = Input.GetAxis("Horizontal") * movespeed;
        vertTranslation *= Time.deltaTime;
        horTranslation *= Time.deltaTime;
        transform.Translate(horTranslation, 0, vertTranslation);
    }
}
