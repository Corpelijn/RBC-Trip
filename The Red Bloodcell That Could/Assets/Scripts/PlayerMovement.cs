using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.VainBuilder;
using Assets.Scripts;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem red;
    private float redstartspeed = 2.5f;
    private float redemmission = 10f;
    private float redmaxparticles = 100f;
    public ParticleSystem white;
    private float whitestartspeed = 2.5f;
    public ParticleSystem purple;
    private float purplestartspeed = 2.5f;

    public static PlayerMovement instance = new PlayerMovement();
    public GameObject target;
    //public float distance = 1.5f;            //10f
    //public float xSpeed = 250f;             //250f
    //public float ySpeed = 120f;             //120f
    //public float yMinLimit = -20f;          //-20f
    //public float yMaxLimit = 80f;           //80f;
    //private float x = 0.0f;                 //0.0f
    //private float y = 0.0f;                 //0.0f

    public Vector3 directionToMove;

    public Text countdown;
    public int countdownValue = 10;
    private bool ready = false;
    private float movespeed = 100000;
    private float scaleVain;

    // Use this for initialization
    void Start()
    {
        instance = this;
        //Vector3 angles = transform.eulerAngles;
        //x = angles.y;
        //y = angles.x;

        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;

        countdown.text = countdownValue.ToString();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void LateUpdate()
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
        if (ready)
            movePlayer();
    }

    public void movePlayer()
    {
        scaleVain = VainBuilder.Instance.GetVain(Player.Instance.currentVain).GetScale();
        //0.25, 0.5, 1, 2, 4
        Debug.Log("scale: " + scaleVain);
        movespeed = (200000 / scaleVain); //* 0.2f);
        red.startSpeed = redstartspeed * scaleVain;
        red.maxParticles = (int)(redmaxparticles * scaleVain);
        red.emissionRate = redemmission * scaleVain;
        //Debug.Log("Movement speed: " + movespeed);

        directionToMove = target.transform.position - this.transform.position;
        //directionToMove.x = 0;
        if (directionToMove.y > 2) { directionToMove.y = 2; }
        target.GetComponent<Rigidbody>().AddForce(directionToMove / movespeed);
        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //Debug.Log(directionToMove);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);

        if (countdownValue != 1)
        {
            countdownValue -= 1;
            countdown.text = countdownValue.ToString();
            StartCoroutine(Countdown());
        }
        else
        {
            ready = true;
        }
    }
}
