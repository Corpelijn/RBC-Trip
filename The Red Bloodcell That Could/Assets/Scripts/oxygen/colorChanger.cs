using UnityEngine;
using System.Collections;

public class colorChanger : MonoBehaviour {

    public Color lerpedColordoel;
    public Color lerpedColorCel;
    public float doelTimer = 0;
    public float celTimer = 0;
    //public float lerpTimer = 0;
    public float lerpSpeed = 2;
    public bool canShoot = true;
    public bool canGet = false;
    public GameObject cel;
    public int timesShot = 0;

    // Use this for initialization
    void Start () {
        lerpedColordoel = Color.blue;
        lerpedColorCel = Color.white;
        this.GetComponent<Renderer>().material.color = Color.blue;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.GetComponent<Renderer>().material.color = lerpedColordoel;
        cel.GetComponent<Renderer>().material.color = lerpedColorCel;
        if (doelTimer > 0)
        {
            doelTimer -= 0.001f;
            lerpedColordoel = Color.Lerp(Color.blue, Color.white, doelTimer);
        }
    }

    void OnParticleCollision()
    {
        if (canShoot)
        {
            timesShot++;
            doelTimer += 0.1f;
            celTimer += 0.1f;
            canGet = true;

            Debug.Log("doel "+ doelTimer);
            Debug.Log("cel "+celTimer);
            lerpedColordoel = Color.Lerp(Color.blue, Color.white, doelTimer);
            lerpedColorCel = Color.Lerp(Color.white, Color.blue, celTimer);
            if (celTimer >= 1 || doelTimer >=1)
            {
                celTimer = 1;
                doelTimer = 1;               
                canShoot = false;
                canGet = true;
                Debug.Log(timesShot);
                timesShot = 0;
            }
        }        
    }
    
    public void getOxigen()
    {
        if (canGet)
        {
            celTimer -= 0.1f;
            canShoot = true;

            Debug.Log("cel " + celTimer);
            timesShot++;
            lerpedColorCel = Color.Lerp(Color.white, Color.blue, celTimer);
            if (celTimer <= 0)
            {
                celTimer = 0;
                canShoot = true;
                canGet = false;
                Debug.Log(timesShot);
                timesShot = 0;
            }
        }        
    }
}
