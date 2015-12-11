using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour {

	public GameObject doel;
	public GameObject particleHolder;
	public ParticleSystem oxygen;

	private float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (transform.position, doel.transform.position);
		if (Input.GetMouseButtonUp(0)) {
			if (oxygen.isPlaying) {
				oxygen.Stop();
			}
		}
		OnMouseDown ();
	}

	void OnMouseDown() {
		if (distance < 10) {
			if (!oxygen.isPlaying) {
				oxygen.Play();
			}
		}
		else {

		}
	}
}
