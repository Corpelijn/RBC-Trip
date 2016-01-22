using UnityEngine;
using System.Collections;

public class flow : MonoBehaviour {

    public AudioSource whoosh;

    private int counter = 0;
    private int playvalue;

	// Use this for initialization
	void Start ()
    {
        playvalue = Random.Range(1, 10);
        StartCoroutine(count());
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator count()
    {
        yield return new WaitForSeconds(1f);
        counter++;
        if (counter == playvalue)
        {
            playvalue += Random.Range(5, 10);
            whoosh.Play();
        }
        StartCoroutine(count());
    }
}
