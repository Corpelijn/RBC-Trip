using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour
{
    public ParticleSystem oxygen;
    public float distance;
    public Camera playerCam;
    private ReadyToPlay rtp;

    // Use this for initialization
    void Start()
    {
        distance = 10;
        //oxygen.Stop();
        //oxygen.Play();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //Ray ray = playerCam.ScreenPointToRay(Vector3.forward);
        //Ray ray = new Ray(falseCam.transform.position, falseplayer.transform.position);
        //Ray ray = new Ray(transform.position, Vector3.forward);
        Vector3 rayDirection = playerCam.transform.TransformDirection(new Vector3(0,0.1f,1));
        Vector3 rayStart = playerCam.transform.position + rayDirection;
        Debug.DrawRay(rayStart, rayDirection * distance, Color.yellow);
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
        if (Physics.Raycast(rayStart, rayDirection, out hit, distance))
        {
            //Debug.Log(hit.collider.tag);
            if (hit.collider.tag == "Brain" || hit.collider.tag == "Liver" || hit.collider.tag == "Stomach" || hit.collider.tag == "LeftKidney" || hit.collider.tag == "RightKidney" || hit.collider.tag == "Intestines")
            {
                //Debug.Log("Im hitting: " + hit.collider.tag);
                //Debug.Log("particle play: " + oxygen.isPlaying);
                if (hit.collider.GetComponent<colorChanger>().canShoot == true)
                {
                    if (!oxygen.isPlaying)
                    //Debug.Log(hit.collider.tag);
                    oxygen.Play();
                }
            }
            else
            {
                if (oxygen.isPlaying)
                {
                    //Debug.Log("Stopping oxygen now!!!!!");
                    oxygen.Stop();
                }
                    
            }
        }
        else
        {
            //oxygen.Stop();
        }
    }

    void OnParticleCollision()
    {
        //Debug.Log("I feel triggered");
        colorChanger cc = new colorChanger();
        cc.getOxigen();
    }
}
