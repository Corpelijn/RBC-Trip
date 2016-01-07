using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour
{
    public ParticleSystem oxygen;
    public float distance;

    // Use this for initialization
    void Start()
    {
        distance = 10;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.yellow);
        if (Physics.Raycast(ray, out hit, distance))
        {
            if (hit.collider.tag == "target")
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
            if (hit.collider.tag == "oxigenGetter")
            {
                oxygen.Stop();
                if (hit.collider.GetComponent<colorChanger>().canGet == true)
                {
                    hit.collider.GetComponent<colorChanger>().getOxigen();
                }
            }
        }
    }
}
