// #######################################
// ---------------------------------------
// ---------------------------------------
// prefrontal cortex -- http://prefrontalcortex.de
// ---------------------------------------
// Full Android Sensor Access for Unity3D
// ---------------------------------------
// Contact:
// 		contact@prefrontalcortex.de
// ---------------------------------------
// #######################################


using UnityEngine;
using System.Collections;

public class TurntableSensorCamera : MonoBehaviour {
	
	public Transform target;
	public float distance;
	public bool useRelativeCameraRotation = true;

    float xRotation;
    float yRotation;
    float zRotation;

    Vector3 totalRotation;
	
	// initial camera and sensor value
	private Quaternion initialCameraRotation = Quaternion.identity;
	private bool gotFirstValue = false;
	
	// Use this for initialization
	void Start ()
	{
		// for distance calculation --> its much easier to make adjusments in the editor, just put
		// your camera where you want it to be
		if(target == null) {Debug.LogWarning("Warning! Target for TurntableSensorCamera is null."); return;}
		
		// if distance is set to zero, use current camera position --> easier setup
		if(distance == 0)
			distance = (transform.position - target.position).magnitude;
		
		// if you start the app, you will be viewing in the same direction your unity camera looks right now
		if(useRelativeCameraRotation)
			initialCameraRotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
		else
			initialCameraRotation = Quaternion.identity;
		// direct call
		// Sensor.Activate(Sensor.Type.RotationVector);
		
		// SensorHelper call with fallback
		SensorHelper.ActivateRotation();
//		SensorHelper.TryForceRotationFallback(RotationFallbackType.OrientationAndAcceleration);
		
		StartCoroutine(Calibration());
	}
	
	IEnumerator Calibration()
	{
		gotFirstValue = false;
		
		while(! SensorHelper.gotFirstValue) {
			SensorHelper.FetchValue();
			yield return null;
		}
		
		SensorHelper.FetchValue();
		
		// wait some frames
		yield return new WaitForSeconds(0.1f);
		
		// Initialize rotation values
		Quaternion initialSensorRotation = SensorHelper.rotation;
		initialCameraRotation *= Quaternion.Euler(0,-initialSensorRotation.eulerAngles.y,0);
		
		// allow updates
		gotFirstValue = true;
	}
	
	// Update is called once per frame
	void LateUpdate()
	{
		// first value gotten from sensor is the offset value for further processing
		if(useRelativeCameraRotation)
		if(!gotFirstValue) return;
	
		// do nothing if there is no target
		if(target == null) return;
        xRotation = initialCameraRotation.x * SensorHelper.rotation.x;
        yRotation = initialCameraRotation.y * SensorHelper.rotation.y;
        zRotation = initialCameraRotation.z * SensorHelper.rotation.z;
        
        transform.rotation = initialCameraRotation * SensorHelper.rotation; // Sensor.rotationQuaternion;
        if (transform.eulerAngles.y < 290 && transform.eulerAngles.y > 180)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 290, transform.eulerAngles.z);
        }
        if (transform.eulerAngles.y > 70 && transform.eulerAngles.y < 180)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 70, transform.eulerAngles.z);
        }
        if (transform.eulerAngles.x > 70 && transform.eulerAngles.x < 180)
        {
            transform.eulerAngles = new Vector3(70, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        transform.position = target.position - transform.forward * distance;
	}

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle < 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
