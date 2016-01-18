using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour {

    public static CameraOrbit instance = new CameraOrbit();
    public GameObject target;
    //public float distance = 1.5f;            //10f
    //public float xSpeed = 250f;             //250f
    //public float ySpeed = 120f;             //120f
    //public float yMinLimit = -20f;          //-20f
    //public float yMaxLimit = 80f;           //80f;
    //private float x = 0.0f;                 //0.0f
    //private float y = 0.0f;                 //0.0f

    public Vector3 directionToMove;

    private bool ready = false;

	// Use this for initialization
	void Start ()
    {
        instance = this;
        //Vector3 angles = transform.eulerAngles;
        //x = angles.y;
        //y = angles.x;

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
	    //if (target)
     //   {
     //       x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
     //       y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

     //       y = ClampAngle(y, yMinLimit, yMaxLimit);

     //       var rotation = Quaternion.Euler(y, x, 0);
     //       var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.transform.position;

     //       distance += Input.GetAxis("Mouse ScrollWheel");
     //       distance = Mathf.Clamp(distance, 1.5f, 5.0f);

     //       transform.rotation = rotation;
     //       transform.position = position;
     //   }
	}

    void FixedUpdate()
    {
        //if (ready)
            movePlayer();
    }

    public void setReady()
    {
        ready = true;
    }

    public float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    public void movePlayer()
    {   
        directionToMove = target.transform.position - this.transform.position;
        //directionToMove.x = 0;
        if (directionToMove.y > 2) { directionToMove.y = 2; }
        target.GetComponent<Rigidbody>().AddForce(directionToMove / 100000);
        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log(directionToMove);
    }
}
