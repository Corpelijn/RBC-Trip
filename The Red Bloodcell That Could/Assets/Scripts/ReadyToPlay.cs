using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyToPlay : MonoBehaviour {

    //public Camera cam;
    //public Slider sliderReady;
    //public GameObject ready;
    //public float maxSliderValue;
    //public float currentSliderValue;
    //public float fillSpeed;
    //public float decreaseSpeed;
    //private Vector3 readyOriginal;
    //private Vector3 readyTarget;
    //public float movespeed = 0.5f;
    private CameraOrbit co;

	// Use this for initialization
	void Start ()
    {
        co = CameraOrbit.instance;
        //sliderReady.maxValue = maxSliderValue;
        //sliderReady.value = 0;

        //readyOriginal = ready.transform.position;
        //readyTarget = new Vector3(ready.transform.position.x, ready.transform.position.y, ready.transform.position.z - 1);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");
            //co.setReady();
        }

        //float length = 20.0f;
        //RaycastHit hit;
        //Vector3 rayDirection = cam.transform.TransformDirection(Vector3.forward);
        //Vector3 rayStart = cam.transform.position + rayDirection;
        //Debug.DrawRay(rayStart, rayDirection * length, Color.blue);
        //if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        //{
        //    if (hit.collider.tag == "Ready")
        //    {
        //        float step = movespeed * Time.deltaTime;
        //        ready.transform.position = Vector3.MoveTowards(ready.transform.position, readyTarget, step);

        //        if (sliderReady.value != maxSliderValue)
        //        {
        //            sliderReady.value += fillSpeed;
        //        }
        //        else if (sliderReady.value == maxSliderValue)
        //        {
        //            Ready();
        //        }
        //    }
        //}
	}

    public void Ready()
    {
        //co.setReady();
    }
}
