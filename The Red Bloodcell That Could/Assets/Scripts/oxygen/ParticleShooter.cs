using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour
{
    public ParticleSystem oxygen;
    public float distance;
    public GameObject doel;
    public Camera playerCam;

    // Use this for initialization
    void Start()
    {
        distance = 10;
        doel = GameObject.FindGameObjectWithTag("Target");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = playerCam.ScreenPointToRay(Vector3.forward);
        //Ray ray = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "Target")
            {
                if (hit.collider.GetComponent<colorChanger>().canShoot == true)
                {
                    if (!oxygen.isPlaying)
                        oxygen.Play();
                }
                else
                {
                    oxygen.Stop();
                }
            }
            else
            {
                oxygen.Stop();
            }
        }
        else
        {
            oxygen.Stop();
        }
    }

    void OnParticleCollision()
    {
        Debug.Log("I feel triggered");
        doel.GetComponent<colorChanger>().getOxigen();
    }
}
