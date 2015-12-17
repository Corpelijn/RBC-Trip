using UnityEngine;
using System.Collections;

public class BloodCellAI : MonoBehaviour {
    public int snelheid = 5;
    private Rigidbody rigidbody;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;
    public GameObject waypoint5;
    private GameObject currentwaypoint;
    public float lookrange;
    private Vector3 lookposition;
    private bool gotwaypoint;
    private int waypointnummer;
    // Use this for initialization
    void Start () {
        rigidbody = this.GetComponent <Rigidbody>();
        //rigidbody.velocity = Vector3.forward * Time.deltaTime * snelheid;
        currentwaypoint = waypoint1;
        gotwaypoint = false;
        waypointnummer = 1;
    }
	
	// Update is called once per frame
	void Update () {
        //snelheid bloedcellen
        if(rigidbody.velocity.magnitude > snelheid)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * snelheid;
        }
        rigidbody.AddForce(transform.forward * snelheid);
        
        //kijk naar waypoint
        if (gotwaypoint == false)
        {
            lookposition = new Vector3(currentwaypoint.transform.position.x + (Random.Range(-lookrange, lookrange)), currentwaypoint.transform.position.y + (Random.Range(-lookrange, lookrange)), currentwaypoint.transform.position.z + (Random.Range(-lookrange, lookrange)));
            gotwaypoint = true;
        }
        rigidbody.transform.LookAt(lookposition);
        float distance = Vector3.Distance(transform.position, currentwaypoint.transform.position);
        
        //krijg nieuwe waypoint
        if (distance < 3)
        {
            gotwaypoint = false;
            NextWaypoint();
        }
	}

    void NextWaypoint()
    {
        if (waypointnummer == 1)
        {
            currentwaypoint = waypoint1;
        }
        if (waypointnummer == 2)
        {
            currentwaypoint = waypoint2;
        }
        if (waypointnummer == 3)
        {
            currentwaypoint = waypoint3;
        }
        if (waypointnummer == 4)
        {
            float random = Random.Range(0, 2);
            if (random == 1)
            {
                currentwaypoint = waypoint4;
            }
            else
            {
                currentwaypoint = waypoint5;
            }   
        }
        waypointnummer++;
    }
}
