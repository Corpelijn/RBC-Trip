using UnityEngine;
using System.Collections;

public class CameraTestScript : MonoBehaviour {

    public float speed = 2.0f;
    public bool inverted = false;

    Quaternion initialPositioning;

    private Vector3 lastMouse = new Vector3(255, 255, 255);
	// Use this for initialization
	void Start () 
    {
        GameObject camParent = GameObject.Find("CardboardMain");
        GameObject camChild = GameObject.Find("Head");
        if (camParent != null && camChild != null)
        {
            camParent.transform.position = transform.position;
            transform.parent = camChild.transform;
            camChild.transform.parent = camParent.transform;
            camParent.transform.Rotate(Vector3.right, 90);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        lastMouse = Input.mousePosition - lastMouse;
        if (!inverted) lastMouse.y = -lastMouse.y; 
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.y, transform.eulerAngles.y + lastMouse.x,0);
        transform.eulerAngles = lastMouse;

        lastMouse = Input.mousePosition;

        Vector3 dir = new Vector3();
        if (Input.GetKey(KeyCode.W)) dir.z += 1.0f;
        if (Input.GetKey(KeyCode.S)) dir.z -= 1.0f;
        if (Input.GetKey(KeyCode.D)) dir.x += 1.0f;
        if (Input.GetKey(KeyCode.A)) dir.x -= 1.0f;

        transform.Translate(dir * speed * Time.deltaTime);

        //Quaternion rotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        //transform.localRotation = rotation;
	}
}
