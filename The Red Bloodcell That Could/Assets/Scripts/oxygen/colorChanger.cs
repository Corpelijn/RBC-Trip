using UnityEngine;
using System.Collections;

public class colorChanger : MonoBehaviour
{

    //lerp colors per organ
    private Color lerpedColorBrain;
    private Color lerpedColorStomach;
    private Color lerpedColorLiver;
    private Color lerpedColorLeftKidney;
    private Color lerpedColorRightKidney;
    private Color lerpedColorIntestines;
    private Color lerpedColorCel;

    //Oxygen timers value from 0 to 1;
    public float brainTimer = 1;
    public float stomachTimer = 1;
    public float liverTimer = 1;
    public float leftKidneyTimer = 1;
    public float rightKidneyTimer = 1;
    public float intestinesTimer = 1;
    public float celTimer = 0;

    //Gameobject of the organs
    private GameObject brain;
    private GameObject stomach;
    private GameObject liver;
    private GameObject leftKidney;
    private GameObject rightKidney;
    private GameObject intestines;
    public GameObject cel;
    private GameObject organ;

    private float lerpSpeed = 2;
    public bool canShoot = true;
    public bool canGet = false;
    private int timesShot = 0;


    // Use this for initialization
    void Start()
    {
        lerpedColorBrain = Color.red;
        lerpedColorStomach = Color.red;
        lerpedColorLiver = Color.red;
        lerpedColorLeftKidney = Color.red;
        lerpedColorRightKidney = Color.red;
        lerpedColorIntestines = Color.red;
        lerpedColorCel = Color.blue;

        //cel = GameObject.FindGameObjectWithTag("PlayerS");
        //brain = GameObject.FindGameObjectWithTag("BrainS");
        //stomach = GameObject.FindGameObjectWithTag("StomachS");
        //liver = GameObject.FindGameObjectWithTag("LiverS");
        //leftKidney = GameObject.FindGameObjectWithTag("LeftKidneyS");
        //rightKidney = GameObject.FindGameObjectWithTag("RightKidneyS");
        //intestines = GameObject.FindGameObjectWithTag("IntestinesS");
        organ = Assets.Scripts.Player.Instance.currentVain;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //brain.GetComponent<Renderer>().material.color = lerpedColorBrain;
        //stomach.GetComponent<Renderer>().material.color = lerpedColorStomach;
        //liver.GetComponent<Renderer>().material.color = lerpedColorLiver;
        //leftKidney.GetComponent<Renderer>().material.color = lerpedColorLeftKidney;
        //rightKidney.GetComponent<Renderer>().material.color = lerpedColorRightKidney;
        //intestines.GetComponent<Renderer>().material.color = lerpedColorIntestines;
        //cel.GetComponent<Renderer>().material.color = lerpedColorCel;
        if (brainTimer > 0)
        {
            brainTimer -= 0.001f;
            lerpedColorBrain = Color.Lerp(Color.blue, Color.red, brainTimer);
            if(organ.tag == "BrainS")
            {
                organ.GetComponent<Renderer>().material.color = lerpedColorBrain;
            }
        }
        if (stomachTimer > 0)
        {
            stomachTimer -= 0.001f;
            lerpedColorStomach = Color.Lerp(Color.blue, Color.red, stomachTimer);
            if (organ.tag == "StomachS")
            {
                organ.GetComponent<Renderer>().material.color = lerpedColorStomach;
            }
        }
        if (liverTimer > 0)
        {
            liverTimer -= 0.001f;
            lerpedColorLiver = Color.Lerp(Color.blue, Color.red, liverTimer);
            if (organ.tag == "LiverS")
            {
                organ.GetComponent<Renderer>().material.color = lerpedColorLiver;
            }
        }
        if (leftKidneyTimer > 0)
        {
            leftKidneyTimer -= 0.001f;
            lerpedColorLeftKidney = Color.Lerp(Color.blue, Color.red, leftKidneyTimer);
            if (organ.tag == "LeftKidneyS")
            {
                organ.GetComponent<Renderer>().material.color = lerpedColorLeftKidney;
            }
        }
        if (rightKidneyTimer > 0)
        {
            rightKidneyTimer -= 0.001f;
            lerpedColorRightKidney = Color.Lerp(Color.blue, Color.red, rightKidneyTimer);
            if (organ.tag == "RightKidneyS")
            {
                organ.GetComponent<Renderer>().material.color = lerpedColorRightKidney;
            }
        }
        if (intestinesTimer > 0)
        {
            intestinesTimer -= 0.001f;
            lerpedColorIntestines = Color.Lerp(Color.blue, Color.red, intestinesTimer);
            if (organ.tag == "IntestinesS")
            {
                organ.GetComponent<Renderer>().material.color = lerpedColorIntestines;
            }
        }
    }

    void OnParticleCollision(Collider other)
    {
        if (canShoot)
        {
            if (other.tag == "Brain")
            {
                brainTimer += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorBrain = Color.Lerp(Color.blue, Color.red, brainTimer);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || brainTimer >= 1)
                {
                    celTimer = 0;
                    brainTimer = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "Stomach")
            {
                stomachTimer += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorStomach = Color.Lerp(Color.blue, Color.red, stomachTimer);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || stomachTimer >= 1)
                {
                    celTimer = 0;
                    stomachTimer = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "Liver")
            {
                liverTimer += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorLiver = Color.Lerp(Color.blue, Color.red, liverTimer);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || liverTimer >= 1)
                {
                    celTimer = 0;
                    liverTimer = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "LeftKidney")
            {
                leftKidneyTimer += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorLeftKidney = Color.Lerp(Color.blue, Color.red, leftKidneyTimer);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || leftKidneyTimer >= 1)
                {
                    celTimer = 0;
                    leftKidneyTimer = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "RightKidney")
            {
                rightKidneyTimer += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorRightKidney = Color.Lerp(Color.blue, Color.red, rightKidneyTimer);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || rightKidneyTimer >= 1)
                {
                    celTimer = 0;
                    rightKidneyTimer = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "Intestines")
            {
                intestinesTimer += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorIntestines = Color.Lerp(Color.blue, Color.red, intestinesTimer);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || intestinesTimer >= 1)
                {
                    celTimer = 0;
                    intestinesTimer = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
        }
    }

    public void getOxigen()
    {
        if (canGet)
        {
            celTimer += 0.1f;
            canShoot = true;

            lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
            if (celTimer <= 0)
            {
                celTimer = 0;
                canShoot = true;
                canGet = false;
                timesShot = 0;
            }
        }
    }


}

