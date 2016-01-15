using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyToPlay : MonoBehaviour {

    public Camera cam;
    public Slider readySlider;
    public GameObject ready;
    public float maxSliderValue;
    public float currentSliderValue;
    public float fillSpeed;
    public float decreaseSpeed;
    private Vector3 readyOriginal;
    private Vector3 readyTarget;

	// Use this for initialization
	void Start ()
    {
        readySlider.maxValue = maxSliderValue;
        readySlider.value = 0;

        readyOriginal = ready.transform.position;
        readyTarget = new Vector3(ready.transform.position.x, ready.transform.position.y, ready.transform.position.z - 1);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        float length = 20.0f;
        RaycastHit hit;
        Vector3 rayDirection = cam.transform.TransformDirection(Vector3.forward);
        Vector3 rayStart = cam.transform.position + rayDirection;
        Debug.DrawRay(rayStart, rayDirection * length, Color.blue);
        if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        {
            if (hit.collider.tag == "Ready")
            {

            }
        }
	}

    public void makeReady()
    {

    }
}
