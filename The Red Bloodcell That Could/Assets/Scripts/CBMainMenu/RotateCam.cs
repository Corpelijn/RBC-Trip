using UnityEngine;
using System.Collections;

public class RotateCam : MonoBehaviour {

    private Camera cam;
    //Fancy but isn't working xD
    //public float smooth = 2.0f;
    //public float tiltAngle = 30.0f;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
            cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, cam.transform.localEulerAngles.y - 2, cam.transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.D))
            cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, cam.transform.localEulerAngles.y + 2, cam.transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.W))
            cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x - 2, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);
        if (Input.GetKey(KeyCode.S))
            cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x + 2, cam.transform.localEulerAngles.y, cam.transform.localEulerAngles.z);

        //RaycastHit hit;
        //Ray ray = cam.ScreenPointToRay(cam);
        //Debug.DrawRay(ray.origin, ray.direction * 100000, Color.red, 1);

        //Fancy but isn't working xD
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        //float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        //Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}

