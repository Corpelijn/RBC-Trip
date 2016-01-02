using UnityEngine;
using System.Collections;

public class colorChanger : MonoBehaviour {

    public Color lerpedColordoel;
    public Color lerpedColorCel;
    public float lerpTimer = 0;
    public float lerpSpeed = 2;
    public bool canShoot = true;
    public GameObject cel;
    public int timesShot = 0;

    // Use this for initialization
    void Start () {
        lerpedColordoel = Color.blue;
        lerpedColorCel = Color.white;
        this.GetComponent<Renderer>().material.color = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Renderer>().material.color = lerpedColordoel;
        cel.GetComponent<Renderer>().material.color = lerpedColorCel;
    }

    void OnParticleCollision(GameObject other)
    {
        if (canShoot)
        {
            timesShot++;
        }       
        lerpTimer += Time.deltaTime * 4;
        lerpedColordoel = Color.Lerp(Color.blue, Color.white, lerpTimer);
        lerpedColorCel = Color.Lerp(Color.white, Color.blue, lerpTimer);
        if (lerpedColordoel.r == 1.000f)
        {
            canShoot = false;
            Debug.Log(timesShot);
        }       
    }
}
