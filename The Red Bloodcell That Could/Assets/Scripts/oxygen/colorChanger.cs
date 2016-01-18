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
    public float brainOxygenLevel = 1;
    public float stomachOxygenLevel = 1;
    public float liverOxygenLevel = 1;
    public float leftKidneyOxygenLevel = 1;
    public float rightKidneyLevel = 1;
    public float intestinesLevel = 1;
    public float celTimer = 0;

    //Gameobject of the organs
    //private GameObject brain;
    //private GameObject stomach;
    //private GameObject liver;
    //private GameObject leftKidney;
    //private GameObject rightKidney;
    //private GameObject intestines;
    public GameObject cel;
    private GameObject organ;

    public bool canShoot = true;
    public bool canGet = false;

    public static colorChanger instance { private set; get; }

    // Use this for initialization
    void Start()
    {
        // Set the instance
        instance = this;

        lerpedColorBrain = Color.red;
        lerpedColorStomach = Color.red;
        lerpedColorLiver = Color.red;
        lerpedColorLeftKidney = Color.red;
        lerpedColorRightKidney = Color.red;
        lerpedColorIntestines = Color.red;
        lerpedColorCel = Color.blue;

        //cel = GameObject.FindGameObjectWithTag("Player");
        //brain = GameObject.FindGameObjectWithTag("BrainS");
        //stomach = GameObject.FindGameObjectWithTag("StomachS");
        //liver = GameObject.FindGameObjectWithTag("LiverS");
        //leftKidney = GameObject.FindGameObjectWithTag("LeftKidneyS");
        //rightKidney = GameObject.FindGameObjectWithTag("RightKidneyS");
        //intestines = GameObject.FindGameObjectWithTag("IntestinesS");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        organ = Assets.Scripts.Player.Instance.currentVain;
        //brain.GetComponent<Renderer>().material.color = lerpedColorBrain;
        //stomach.GetComponent<Renderer>().material.color = lerpedColorStomach;
        //liver.GetComponent<Renderer>().material.color = lerpedColorLiver;
        //leftKidney.GetComponent<Renderer>().material.color = lerpedColorLeftKidney;
        //rightKidney.GetComponent<Renderer>().material.color = lerpedColorRightKidney;
        //intestines.GetComponent<Renderer>().material.color = lerpedColorIntestines;
        //cel.GetComponent<Renderer>().material.color = lerpedColorCel;
        if (organ != null)
        {
            if (brainOxygenLevel > 0)
            {
                brainOxygenLevel -= 0.001f;
                lerpedColorBrain = Color.Lerp(Color.blue, Color.red, brainOxygenLevel);
                if (organ.tag == "Brain")
                {
                    organ.GetComponentInChildren<Renderer>().material.color = lerpedColorBrain;
                }
            }
            if (stomachOxygenLevel > 0)
            {
                stomachOxygenLevel -= 0.001f;
                lerpedColorStomach = Color.Lerp(Color.blue, Color.red, stomachOxygenLevel);
                if (organ.tag == "Stomach")
                {
                    organ.GetComponentInChildren<Renderer>().material.color = lerpedColorStomach;
                }
            }
            if (liverOxygenLevel > 0)
            {
                liverOxygenLevel -= 0.001f;
                lerpedColorLiver = Color.Lerp(Color.blue, Color.red, liverOxygenLevel);
                if (organ.tag == "Liver")
                {
                    organ.GetComponentInChildren<Renderer>().material.color = lerpedColorLiver;
                }
            }
            if (leftKidneyOxygenLevel > 0)
            {
                leftKidneyOxygenLevel -= 0.001f;
                lerpedColorLeftKidney = Color.Lerp(Color.blue, Color.red, leftKidneyOxygenLevel);
                if (organ.tag == "LeftKidney")
                {
                    organ.GetComponentInChildren<Renderer>().material.color = lerpedColorLeftKidney;
                }
            }
            if (rightKidneyLevel > 0)
            {
                rightKidneyLevel -= 0.001f;
                lerpedColorRightKidney = Color.Lerp(Color.blue, Color.red, rightKidneyLevel);
                if (organ.tag == "RightKidney")
                {
                    organ.GetComponentInChildren<Renderer>().material.color = lerpedColorRightKidney;
                }
            }
            if (intestinesLevel > 0)
            {
                intestinesLevel -= 0.001f;
                lerpedColorIntestines = Color.Lerp(Color.blue, Color.red, intestinesLevel);
                if (organ.tag == "Intestines")
                {
                    organ.GetComponentInChildren<Renderer>().material.color = lerpedColorIntestines;
                }
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        if (canShoot)
        {
            if (other.tag == "Brain")
            {
                brainOxygenLevel += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorBrain = Color.Lerp(Color.blue, Color.red, brainOxygenLevel);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || brainOxygenLevel >= 1)
                {
                    celTimer = 0;
                    brainOxygenLevel = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "Stomach")
            {
                stomachOxygenLevel += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorStomach = Color.Lerp(Color.blue, Color.red, stomachOxygenLevel);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || stomachOxygenLevel >= 1)
                {
                    celTimer = 0;
                    stomachOxygenLevel = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "Liver")
            {
                liverOxygenLevel += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorLiver = Color.Lerp(Color.blue, Color.red, liverOxygenLevel);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || liverOxygenLevel >= 1)
                {
                    celTimer = 0;
                    liverOxygenLevel = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "LeftKidney")
            {
                leftKidneyOxygenLevel += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorLeftKidney = Color.Lerp(Color.blue, Color.red, leftKidneyOxygenLevel);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || leftKidneyOxygenLevel >= 1)
                {
                    celTimer = 0;
                    leftKidneyOxygenLevel = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "RightKidney")
            {
                rightKidneyLevel += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorRightKidney = Color.Lerp(Color.blue, Color.red, rightKidneyLevel);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || rightKidneyLevel >= 1)
                {
                    celTimer = 0;
                    rightKidneyLevel = 1;
                    canShoot = false;
                    canGet = true;
                }
            }
            if (other.tag == "Intestines")
            {
                intestinesLevel += 0.1f;
                celTimer -= 0.1f;
                canGet = true;

                lerpedColorIntestines = Color.Lerp(Color.blue, Color.red, intestinesLevel);
                lerpedColorCel = Color.Lerp(Color.blue, Color.red, celTimer);
                if (celTimer <= 0 || intestinesLevel >= 1)
                {
                    celTimer = 0;
                    intestinesLevel = 1;
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
            }
        }
    }


}

