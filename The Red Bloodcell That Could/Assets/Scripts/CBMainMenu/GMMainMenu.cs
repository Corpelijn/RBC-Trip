using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GMMainMenu : MonoBehaviour
{
    //GameObjects
    public Camera cam;
    public Slider sliderStart;
    public Slider sliderQuit;
    public Slider sliderOptions;
    //public Slider sliderOptionsTerug;
    public GameObject start;
    public GameObject quit;
    public GameObject options;
    //public GameObject optionsVelden;
    public GameObject UI;

    //Slider values
    public float maxSliderValue;            //50f
    public float currentSliderValue;        //0f
    public float fillSpeed;                 //0.3f
    public float decreaseSpeed;             //0.2f

    //Positions
    private Vector3 startOriginal;
    private Vector3 quitOriginal;
    private Vector3 optionsOriginal;
    private Vector3 startTarget;
    private Vector3 quitTarget;
    private Vector3 optionsTarget;

    //Camera rotation
    //private Quaternion camCurrent;
    //private Quaternion camOptions;
    //private Quaternion camOptionsValues;
    //public float smooth;                    //2.0f
    //public float tiltAngle;                 //30f

    //Movespeed
    public float movespeed;                 //0.5f

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;

        //Set all the sliders
        sliderStart.maxValue = maxSliderValue;
        sliderQuit.maxValue = maxSliderValue;
        sliderOptions.maxValue = maxSliderValue;
        sliderStart.value = 0;
        sliderQuit.value = 0;
        sliderOptions.value = 0;

        //Set all positions
        startOriginal = start.transform.position;
        quitOriginal = quit.transform.position;
        optionsOriginal = options.transform.position;
        startTarget = new Vector3(start.transform.position.x, start.transform.position.y, start.transform.position.z - 1);
        quitTarget = new Vector3(quit.transform.position.x + 1, quit.transform.position.y, quit.transform.position.z);
        optionsTarget = new Vector3(options.transform.position.x - 1, options.transform.position.y, options.transform.position.z);

        //cam.transform.LookAt(startOriginal);
        UI.transform.rotation = new Quaternion(UI.transform.rotation.x, cam.transform.rotation.y, UI.transform.rotation.z, UI.transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        float length = 10.0f;
        RaycastHit hit;
        Vector3 rayDirection = cam.transform.TransformDirection(Vector3.forward);
        Vector3 rayStart = cam.transform.position + rayDirection;
        Debug.DrawRay(rayStart, rayDirection * length, Color.green);
        if (Physics.Raycast(rayStart, rayDirection, out hit, length))
        {
            if (hit.collider.tag == "MMPlay")
            {
                float step = movespeed * Time.deltaTime;
                start.transform.position = Vector3.MoveTowards(start.transform.position, startTarget, step);

                if (sliderStart.value != maxSliderValue)
                {
                    //slider slowly fills
                    sliderStart.value += fillSpeed;
                } //when slider full
                else if (sliderStart.value == maxSliderValue)
                {
                    Play();
                }
            }
            else if (hit.collider.tag == "MMOptions")
            {
                float step = movespeed * Time.deltaTime;
                options.transform.position = Vector3.MoveTowards(options.transform.position, optionsTarget, step);

                if (sliderOptions.value != maxSliderValue)
                {
                    //slider slowly fills
                    sliderOptions.value += fillSpeed;
                } //when slider full
                else if (sliderOptions.value == maxSliderValue)
                {
                    //Options();
                }
            }
            else if (hit.collider.tag == "MMQuit")
            {
                float step = movespeed * Time.deltaTime;
                quit.transform.position = Vector3.MoveTowards(quit.transform.position, quitTarget, step);

                if (sliderQuit.value != maxSliderValue)
                {
                    //slider slowly fills
                    sliderQuit.value += fillSpeed;
                } //when slider full
                else if (sliderQuit.value == maxSliderValue)
                {
                    Quit();
                }
            }
            else
            {
                DecreaseSliders();

                if (start.transform.position != startOriginal)
                {
                    float step = movespeed * Time.deltaTime;
                    start.transform.position = Vector3.MoveTowards(start.transform.position, startOriginal, step);
                }
                if (options.transform.position != optionsOriginal)
                {
                    float step = movespeed * Time.deltaTime;
                    options.transform.position = Vector3.MoveTowards(options.transform.position, optionsOriginal, step);
                }
                if (quit.transform.position != quitOriginal)
                {
                    float step = movespeed * Time.deltaTime;
                    quit.transform.position = Vector3.MoveTowards(quit.transform.position, quitOriginal, step);
                }
            }
        }
        else
        {
            DecreaseSliders();

            if (start.transform.position != startOriginal)
            {
                float step = movespeed * Time.deltaTime;
                start.transform.position = Vector3.MoveTowards(start.transform.position, startOriginal, step);
            }
            if (options.transform.position != optionsOriginal)
            {
                float step = movespeed * Time.deltaTime;
                options.transform.position = Vector3.MoveTowards(options.transform.position, optionsOriginal, step);
            }
            if (quit.transform.position != quitOriginal)
            {
                float step = movespeed * Time.deltaTime;
                quit.transform.position = Vector3.MoveTowards(quit.transform.position, quitOriginal, step);
            }
        }
    }

    public void DecreaseSliders()
    {
        if (sliderStart.value > 0)
            sliderStart.value -= decreaseSpeed;
        if (sliderOptions.value > 0)
            sliderOptions.value -= decreaseSpeed;
        if (sliderQuit.value > 0)
            sliderQuit.value -= decreaseSpeed;
    }

    public void Play()
    {
        //Application.LoadLevel("TestMap");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }

    public void Options()
    {
        //to do
        //show options
    }
}
