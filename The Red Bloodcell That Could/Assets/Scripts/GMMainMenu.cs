using UnityEngine;
using System.Collections;

public class GMMainMenu : MonoBehaviour
{

    public Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Move camera forwards
        if (Input.GetKey(KeyCode.UpArrow))
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 0.1f);

        //Move camera backwards
        if (Input.GetKey(KeyCode.DownArrow))
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z - 0.1f);

        //Move camera left
        if (Input.GetKey(KeyCode.LeftArrow))
            cam.transform.position = new Vector3(cam.transform.position.x - 0.1f, cam.transform.position.y, cam.transform.position.z);

        //Move camera right
        if (Input.GetKey(KeyCode.RightArrow))
            cam.transform.position = new Vector3(cam.transform.position.x + 0.1f, cam.transform.position.y, cam.transform.position.z);

        //Move camera up and down
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        cam.transform.position += Vector3.down * zoom * Time.deltaTime * 200.0f;

        //Move camera up
        if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.KeypadPlus))
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 0.1f, cam.transform.position.z);

        //Move camera down
        if (Input.GetKey(KeyCode.Minus) || Input.GetKey(KeyCode.KeypadMinus))
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.1f, cam.transform.position.z);
    }
}
