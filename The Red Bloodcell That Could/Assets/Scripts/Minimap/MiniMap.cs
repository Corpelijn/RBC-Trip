using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.VainBuilder;
using Assets.Scripts;

public class MiniMap : MonoBehaviour {

    public Image dotHead;
    public Image dotLungsLeft;
    public Image dotLungsRight;
    public Image dotHeart;
    public Image dotLiver;
    public Image dotStomach;
    public Image dotKidneyLeft;
    public Image dotKindeyRight;
    public Image dotIntestines;
    public Image dotHeartLung;
    public Image dotHeartHead;
    public Image dotHeartStomach;
    public Image dotHeartLiver;
    public Image dotHeartIntestines;
    public Image dotHeartKidneys;

    private List<Image> dots;

    private Image activeImage;

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
        activeImage = dotHeart;

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

        dots = new List<Image>();
        dots.Add(dotHead);
        dots.Add(dotLungsLeft);
        dots.Add(dotLungsRight);
        dots.Add(dotHeart);
        dots.Add(dotLiver);
        dots.Add(dotStomach);
        dots.Add(dotKidneyLeft);
        dots.Add(dotKindeyRight);
        dots.Add(dotIntestines);
        dots.Add(dotHeartLung);
        dots.Add(dotHeartHead);
        dots.Add(dotHeartStomach);
        dots.Add(dotHeartLiver);
        dots.Add(dotHeartIntestines);
        dots.Add(dotHeartKidneys);
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

        BloedLocatie loc = Distance.GetLocatie(VainBuilder.Instance.GetVain(Player.Instance.currentVain).GetID());
        //Debug.Log("loc: " + loc);
        if (loc == BloedLocatie.Darmen)
        {
            setImagesInactive();
            dotIntestines.enabled = true;
        }
        if (loc == BloedLocatie.HartL || loc == BloedLocatie.HartR)
        {
            setImagesInactive();
            dotHeart.enabled = true;
        }
        if (loc == BloedLocatie.LongL)
        {
            setImagesInactive();
            dotLungsLeft.enabled = true;
        }
        if (loc == BloedLocatie.LongR)
        {
            setImagesInactive();
            dotLungsRight.enabled = true;
        }
        if (loc == BloedLocatie.Hersenen)
        {
            //Debug.Log("Ik ben in de hersenen");
            setImagesInactive();
            dotHead.enabled = true;
        }
        if (loc == BloedLocatie.Maag)
        {
            setImagesInactive();
            dotStomach.enabled = true;
        }
        if (loc == BloedLocatie.Lever)
        {
            setImagesInactive();
            dotLiver.enabled = true;
        }
        if (loc == BloedLocatie.NierL)
        {
            setImagesInactive();
            dotKidneyLeft.enabled = true;
        }
        if (loc == BloedLocatie.NierR)
        {
            setImagesInactive();
            dotKindeyRight.enabled = true;
        }
        if (loc == BloedLocatie.Ingang_Longen || loc == BloedLocatie.Uitgang_Longen)
        {
            setImagesInactive();
            dotHeartLung.enabled = true;
        }
        if (loc == BloedLocatie.Heen_HersenenHart || loc == BloedLocatie.Terug_HersenenHart)
        {
            setImagesInactive();
            dotHeartHead.enabled = true;
        }
        if (loc == BloedLocatie.Heen_Maag || loc == BloedLocatie.Terug_Maag)
        {
            setImagesInactive();
            dotHeartStomach.enabled = true;
        }
        if (loc == BloedLocatie.Heen_Lever || loc == BloedLocatie.Terug_Lever)
        {
            setImagesInactive();
            dotHeartLiver.enabled = true;
        }
        if (loc == BloedLocatie.Heen_Darmen)
        {
            setImagesInactive();
            dotHeartIntestines.enabled = true;
        }
        if (loc == BloedLocatie.Splitsing_Nieren || loc == BloedLocatie.Samenkoming_Nieren)
        {
            setImagesInactive();
            dotHeartKidneys.enabled = true;
        }
	}

    public void setImagesInactive()
    {
        foreach(Image i in dots)
        {
             i.enabled = false;
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
