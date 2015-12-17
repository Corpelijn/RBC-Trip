using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour {

	public ParticleSystem oxygen;
	public float distance;

	// Use this for initialization
	void Start () {
		distance = 10;
		//particleHolder.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Ray ray = new Ray (transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "target")
            {
                if (!oxygen.isPlaying)
                    oxygen.Play();
            }
        }
        else
        {
            oxygen.Stop();
        }
        Debug.DrawRay (ray.origin, ray.direction * distance, Color.yellow);

//		distance = Vector3.Distance (transform.position, doel.transform.position);
//
//		if (distance < 10) {
//			float length = 10.0f;
//			RaycastHit hit;
//			Vector3 rayDirection = transform.TransformDirection(Vector3.forward);
//			Vector3 rayStart = transform.position + rayDirection;
//			Debug.DrawLine(rayStart, rayDirection * length, Color.yellow);
//			//Debug.DrawRay(rayStart, rayDirection * length, Color.yellow);
//			if (Physics.Raycast (rayStart, rayDirection, out hit, length)) {
//				if (hit.collider.tag == "target")
//					oxygen.Play();
//				else
//					oxygen.Stop();
//			}
//			
//		}
//		else {
//			if (oxygen.isPlaying) {
//				oxygen.Stop();
//				particleHolder.transform.position = transform.position;
//			}
//		}
	}

//	void OnMouseDown() {
//		if (distance < 10) {
//			float length = 10.0f;
//			RaycastHit hit;
//			Vector3 rayDirection = transform.TransformDirection(Vector3.forward);
//			Vector3 rayStart = transform.position + rayDirection;
//			Debug.DrawLine(rayStart, rayDirection * length, Color.yellow);
//			//Debug.DrawRay(rayStart, rayDirection * length, Color.yellow);
//			if (Physics.Raycast (rayStart, rayDirection, out hit, length)) {
//				if (hit.collider.tag == "target") {
//					if (!oxygen.isPlaying) {
//						oxygen.Play();
//					}
//				}
//			}
//
//		}
//		else {
//
//		}
//	}
}
