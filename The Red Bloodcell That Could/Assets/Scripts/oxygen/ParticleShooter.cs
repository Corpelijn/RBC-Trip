using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour
{

    public ParticleSystem oxygen;
    public GameObject doel;
    public float distance;
    public Color lerpedColor = Color.white;

    // Use this for initialization
    void Start()
    {
        distance = 10;
        //particleHolder.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "target")
            {
                if (!oxygen.isPlaying)
                    oxygen.Play();
                lerpedColor = Color.Lerp(Color.white, Color.black, Time.time);
            }
        }
        else
        {
            oxygen.Stop();
        }
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
    }
}
