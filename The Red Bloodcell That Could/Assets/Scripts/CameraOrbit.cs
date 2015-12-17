using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {

    public Transform target;
    public float distance = 10f;            //10f
    public float xSpeed = 250f;             //250f
    public float ySpeed = 120f;             //120f
    public float yMinLimit = -20f;          //-20f
    public float yMaxLimit = 80f;           //80f;
    private float x = 0.0f;                 //0.0f
    private float y = 0.0f;                 //0.0f

	// Use this for initialization
	void Start ()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
	    if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            distance += Input.GetAxis("Mouse ScrollWheel");
            distance = Mathf.Clamp(distance, 1.5f, 5.0f);

            transform.rotation = rotation;
            transform.position = position;
        }
	}

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
