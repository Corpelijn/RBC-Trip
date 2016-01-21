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

    private colorChanger cc;

    // Use this for initialization
    void Start ()
    {
        cc = new colorChanger();
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
            s.maxValue = 100;
            s.minValue = 0;
            s.value = 100;
            s.wholeNumbers = false;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        head.value = cc.brainOxygenLevel;
        liver.value = cc.liverOxygenLevel;
        intestines.value = cc.intestinesLevel;
        stomach.value = cc.stomachOxygenLevel;
        kidneyleft.value = cc.leftKidneyOxygenLevel;
        kidneyright.value = cc.rightKidneyLevel;

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
        //else
        //{
        //    if (canReduceOxygen)
        //        StartCoroutine(ReduceOxygen());

        //    if (canIncreaseHead)
        //        StartCoroutine(IncreaseOxygenHead());

        //    if (canIncreaseIntestines)
        //        StartCoroutine(IncreaseOxygenIntestines());

        //    if (canIncreaseKidneyLeft)
        //        StartCoroutine(IncreaseOxygenKidneyLeft());

        //    if (canIncreaseKidneyRight)
        //        StartCoroutine(IncreaseOxygenKidneyRight());

        //    if (canIncreaseLiver)
        //        StartCoroutine(IncreaseOxygenLiver());

        //    if (canIncreaseStomach)
        //        StartCoroutine(IncreaseOxygenStomach());

        //}

        BloedLocatie loc = Distance.GetLocatie(VainBuilder.Instance.GetVain(Player.Instance.currentVain).GetID());
        if (loc == BloedLocatie.Darmen)
        {
            activeImage.enabled = false;
            dotIntestines.enabled = true;
            activeImage = dotIntestines;
        }
        if (loc == BloedLocatie.HartL || loc == BloedLocatie.HartR)
        {
            activeImage.enabled = false;
            dotHeart.enabled = true;
            activeImage = dotHeart;
        }
        if (loc == BloedLocatie.LongL)
        {
            activeImage.enabled = false;
            dotLungsLeft.enabled = true;
            activeImage = dotLungsLeft;
        }
        if (loc == BloedLocatie.LongR)
        {
            activeImage.enabled = false;
            dotLungsRight.enabled = true;
            activeImage = dotLungsRight;
        }
        if (loc == BloedLocatie.Hersenen)
        {
            activeImage.enabled = false;
            dotHead.enabled = true;
            activeImage = dotHead;
        }
        if (loc == BloedLocatie.Maag)
        {
            activeImage.enabled = false;
            dotStomach.enabled = true;
            activeImage = dotStomach;
        }
        if (loc == BloedLocatie.Lever)
        {
            activeImage.enabled = false;
            dotLiver.enabled = true;
            activeImage = dotLiver;
        }
        if (loc == BloedLocatie.NierL)
        {
            activeImage.enabled = false;
            dotKidneyLeft.enabled = true;
            activeImage = dotKidneyLeft;
        }
        if (loc == BloedLocatie.NierR)
        {
            activeImage.enabled = false;
            dotKindeyRight.enabled = true;
            activeImage = dotKindeyRight;
        }
        if (loc == BloedLocatie.Ingang_Longen || loc == BloedLocatie.Uitgang_Longen)
        {
            activeImage.enabled = false;
            dotHeartLung.enabled = true;
            activeImage = dotHeartLung;
        }
        if (loc == BloedLocatie.Heen_HersenenHart || loc == BloedLocatie.Terug_HersenenHart)
        {
            activeImage.enabled = false;
            dotHeartHead.enabled = true;
            activeImage = dotHeartHead;
        }
        if (loc == BloedLocatie.Heen_Maag || loc == BloedLocatie.Terug_Maag)
        {
            activeImage.enabled = false;
            dotHeartStomach.enabled = true;
            activeImage = dotHeartStomach;
        }
        if (loc == BloedLocatie.Heen_Lever || loc == BloedLocatie.Terug_Lever)
        {
            activeImage.enabled = false;
            dotHeartLiver.enabled = true;
            activeImage = dotHeartLiver;
        }
        if (loc == BloedLocatie.Heen_Darmen)
        {
            activeImage.enabled = false;
            dotHeartIntestines.enabled = true;
            activeImage = dotHeartIntestines;
        }
        if (loc == BloedLocatie.Splitsing_Nieren || loc == BloedLocatie.Samenkoming_Nieren)
        {
            activeImage.enabled = false;
            dotHeartKidneys.enabled = true;
            activeImage = dotHeartKidneys;
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
