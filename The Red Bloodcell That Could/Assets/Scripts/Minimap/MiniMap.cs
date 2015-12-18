using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MiniMap : MonoBehaviour {

    public Slider head;
    public Slider liver;
    public Slider intestines;
    public Slider stomach;
    public Slider kidneyleft;
    public Slider kidneyright;

    public float headOxygenReduceSpeed;
    public float liverOxygenReduceSpeed;
    public float intestinesOxygenReduceSpeed;
    public float stomachOxygenReduceSpeed;
    public float kidneysOxygenReduceSpeed;

    public float increaseOxygenAmount;

    private bool canReduceOxygen;

    private List<Slider> sliders;

    // Use this for initialization
    void Start ()
    {
        sliders = new List<Slider>();
        canReduceOxygen = true;
        sliders.Add(head);
        sliders.Add(liver);
        sliders.Add(intestines);
        sliders.Add(stomach);
        sliders.Add(kidneyleft);
        sliders.Add(kidneyright);
        foreach (Slider s in sliders)
        {
            s.maxValue = 50;
            s.minValue = 0;
            s.value = 50;
            s.wholeNumbers = false;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.G))
        {
            if (Input.GetKey(KeyCode.A))
                head.value += increaseOxygenAmount;
            if (Input.GetKey(KeyCode.S))
                liver.value += increaseOxygenAmount;
            if (Input.GetKey(KeyCode.D))
                intestines.value += increaseOxygenAmount;
            if (Input.GetKey(KeyCode.F))
                stomach.value += increaseOxygenAmount;
            if (Input.GetKey(KeyCode.G))
            {
                kidneyleft.value += increaseOxygenAmount;
                kidneyright.value += increaseOxygenAmount;
            }
        }
        else
        {
            if (canReduceOxygen)
                StartCoroutine(ReduceOxygen());
        }
	}

    IEnumerator ReduceOxygen()
    {
        canReduceOxygen = false;
        yield return new WaitForSeconds(0.25f);
        head.value -= headOxygenReduceSpeed;
        liver.value -= liverOxygenReduceSpeed;
        intestines.value -= intestinesOxygenReduceSpeed;
        stomach.value -= stomachOxygenReduceSpeed;
        kidneyleft.value -= kidneysOxygenReduceSpeed;
        kidneyright.value -= kidneysOxygenReduceSpeed;
        canReduceOxygen = true;
    }
}
