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

    private bool canReduceOxygen = true;

    private List<Slider> sliders;

    private bool canIncreaseHead = true;
    private bool canIncreaseLiver = true;
    private bool canIncreaseIntestines = true;
    private bool canIncreaseStomach = true;
    private bool canIncreaseKidneyLeft = true;
    private bool canIncreaseKidneyRight = true;

    // Use this for initialization
    void Start ()
    {
        sliders = new List<Slider>();
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

            if (canIncreaseHead)
                StartCoroutine(IncreaseOxygenHead());

            if (canIncreaseIntestines)
                StartCoroutine(IncreaseOxygenIntestines());

            if (canIncreaseKidneyLeft)
                StartCoroutine(IncreaseOxygenKidneyLeft());

            if (canIncreaseKidneyRight)
                StartCoroutine(IncreaseOxygenKidneyRight());

            if (canIncreaseLiver)
                StartCoroutine(IncreaseOxygenLiver());

            if (canIncreaseStomach)
                StartCoroutine(IncreaseOxygenStomach());

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

    IEnumerator IncreaseOxygenHead()
    {
        canIncreaseHead = false;
        float time = Random.Range(10, 20);
        yield return new WaitForSeconds(time);
        head.value += increaseOxygenAmount;
        canIncreaseHead = true;
    }

    IEnumerator IncreaseOxygenLiver()
    {
        canIncreaseLiver = false;
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(time);
        liver.value += increaseOxygenAmount;
        canIncreaseLiver = true;
    }

    IEnumerator IncreaseOxygenIntestines()
    {
        canIncreaseIntestines = false;
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(time);
        intestines.value += increaseOxygenAmount;
        canIncreaseIntestines = true;
    }

    IEnumerator IncreaseOxygenStomach()
    {
        canIncreaseStomach = false;
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(time);
        stomach.value += increaseOxygenAmount;
        canIncreaseStomach = true;
    }

    IEnumerator IncreaseOxygenKidneyLeft()
    {
        canIncreaseKidneyLeft = false;
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(time);
        kidneyleft.value += increaseOxygenAmount;
        canIncreaseKidneyLeft = true;
    }

    IEnumerator IncreaseOxygenKidneyRight()
    {
        canIncreaseKidneyRight = false;
        float time = Random.Range(20, 30);
        yield return new WaitForSeconds(time);
        kidneyright.value += increaseOxygenAmount;
        canIncreaseKidneyRight = true;
    }
}
