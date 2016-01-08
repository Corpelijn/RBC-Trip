using UnityEngine;
using System.Collections;

public class PlayerRotationMovement : MonoBehaviour {

    public GameObject PlayerRotation;

    RaycastHit yAxisUp;
    RaycastHit yAxisDown;
    RaycastHit xAxisLeft;
    RaycastHit xAxisRight;

    public bool inMiddle;
    public bool correctAlignment;

	// Use this for initialization
	void Start () 
    {
        inMiddle = false;
        correctAlignment = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        rayCasts();
        checkMiddleAlignment();
	    //checkRayDistance();
        //checkRayAngles();
	}

    void rayCasts()
    {
        Ray rayUp = new Ray(PlayerRotation.transform.position, transform.up);
        Ray rayDown = new Ray(PlayerRotation.transform.position, -transform.up);
        Ray rayLeft = new Ray(PlayerRotation.transform.position, -transform.right);
        Ray rayRight = new Ray(PlayerRotation.transform.position, transform.right);

        if (Physics.Raycast(rayUp, out yAxisUp))
        {
            Debug.Log("Raycast Angle up: " + Vector3.Angle(yAxisUp.normal, PlayerRotation.transform.position));
            //Debug.Log("Raycast Distance up: " + yAxisUp.distance);
        }

        if (Physics.Raycast(rayDown, out yAxisDown))
        {
            Debug.Log("Raycast Angle down: " + Vector3.Angle(yAxisDown.normal, PlayerRotation.transform.position)); 
            //Debug.Log("Raycast Distance down: " + yAxisDown.distance);
        }

        if (Physics.Raycast(rayLeft, out xAxisLeft))
        {
            Debug.Log("Raycast Angle left: " + Vector3.Angle(xAxisLeft.normal, PlayerRotation.transform.position));
            //Debug.Log("Raycast Distance left: " + xAxisLeft.distance);
        }

        if (Physics.Raycast(rayRight, out xAxisRight))
        {
            Debug.Log("Raycast Angle right: " + Vector3.Angle(xAxisRight.normal, PlayerRotation.transform.position));
            //Debug.Log("Raycast Distance right: " + xAxisRight.distance);
        }

        //Draw Raylines for debugging
        Debug.DrawRay(rayUp.origin, rayUp.direction * 500, Color.blue);
        Debug.DrawRay(rayDown.origin, rayDown.direction * 500, Color.blue);
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * 500, Color.blue);
        Debug.DrawRay(rayRight.origin, rayRight.direction * 500, Color.blue);
    }

    void checkMiddleAlignment()
    {
        inMiddle = false;

        bool middleYAxis = false;
        bool middleXAxis = false;

        float minPercentageY = yAxisUp.distance * 0.90f; ;
        float maxPercentageY = yAxisUp.distance * 1.10f; ;
        float minPercentageX = xAxisLeft.distance * 0.90f; ;
        float maxPercentageX = xAxisLeft.distance * 1.10f; ;

        //Check if Y is in middle
        if (minPercentageY < yAxisDown.distance && maxPercentageY > yAxisDown.distance)
        {
            middleYAxis = true;
        }
        else
        {
            middleYAxis = false;
            return;
        }

        //Check if X is in middle
        if (minPercentageX < xAxisRight.distance && maxPercentageX > xAxisRight.distance)
        {
            middleXAxis = true;
        }
        else
        {
            middleXAxis = false;
            return;
        }

        inMiddle = true;
    }

    void checkRotationAlignment()
    {
        //if (LeftRayCastHitAngle == RightRayCastHitAngle && UpRayCastHitAngle == DownRayCastHitAngle)
        //{
        //    correctAlignment = true;
        //}
    }

    void rotateForCorrectAlignment()
    {
        //if (correctAlignment)
        //{
        //    return;
        //}

        //if (TurnedTooMuchRight)
        //{
        //    GoLeft;
        //    return;
        //}
        //if (TurnedTooMuchLeft)
        //{
        //    GoRight;
        //    return;
        //}
        //if (TiltedTooMuchForward)
        //{
        //    TiltBack;
        //    return;
        //}
        //if (TiltedTooMuchBackward)
        //{
        //    TiltForward;
        //    return;
        //}
    }

    void moveForward()
    {
        if(inMiddle) 
        {
            //Cell Move Forward please
        }
    }
}
