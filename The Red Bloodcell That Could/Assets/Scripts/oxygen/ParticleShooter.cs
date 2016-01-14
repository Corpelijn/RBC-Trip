using UnityEngine;
using System.Collections;

public class ParticleShooter : MonoBehaviour
{
    public ParticleSystem oxygen;
    public float distance;
    public Camera playerCam;

    // Use this for initialization
    void Start()
    {
        distance = 10;
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
            if (hit.collider.tag == "Brain" || hit.collider.tag == "Liver" || hit.collider.tag == "Stomach" || hit.collider.tag == "LeftKidney" || hit.collider.tag == "RightKidney" || hit.collider.tag == "Intestines")
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
        colorChanger cc = new colorChanger();
        cc.getOxigen();
    }
}
