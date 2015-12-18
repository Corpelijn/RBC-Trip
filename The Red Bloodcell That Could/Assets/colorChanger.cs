using UnityEngine;
using System.Collections;

public class colorChanger : MonoBehaviour {

    public Color lerpedColor = Color.white;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnParticleCollision(GameObject other)
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Time.time / 10);
        Debug.Log("i feel triggered");
    }
}
