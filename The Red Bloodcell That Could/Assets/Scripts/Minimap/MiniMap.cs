using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.VainBuilder;
using Assets.Scripts;
using Assets.Scripts.VainBuilder.Organen;

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

    //private colorChanger cc;

    // Use this for initialization
    void Start ()
    {
        //cc = new colorChanger();
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
        //head.value = cc.brainOxygenLevel * 100;
        //liver.value = cc.liverOxygenLevel * 100;
        //intestines.value = cc.intestinesLevel * 100;
        //stomach.value = cc.stomachOxygenLevel * 100;
        //kidneyleft.value = cc.leftKidneyOxygenLevel * 100;
        //kidneyright.value = cc.rightKidneyLevel * 100;

        head.value = ((Orgaan)VainBuilder.Instance.GetVain((int)BloedLocatie.Brain)).GetZuurstof() * 100;
        liver.value = ((Orgaan)VainBuilder.Instance.GetVain((int)BloedLocatie.Liver)).GetZuurstof() * 100;
        intestines.value = ((Orgaan)VainBuilder.Instance.GetVain((int)BloedLocatie.Colon)).GetZuurstof() * 100;
        stomach.value = ((Orgaan)VainBuilder.Instance.GetVain((int)BloedLocatie.Stomach)).GetZuurstof() * 100;
        kidneyleft.value = ((Orgaan)VainBuilder.Instance.GetVain((int)BloedLocatie.left_Kidney)).GetZuurstof() * 100;
        kidneyright.value = ((Orgaan)VainBuilder.Instance.GetVain((int)BloedLocatie.right_Kidney)).GetZuurstof() * 100;

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
        //Debug.Log("loc: " + loc);
        if (loc == BloedLocatie.Colon)
        {
            setImagesInactive();
            dotIntestines.enabled = true;
        }
        if (loc == BloedLocatie.left_Ventricle || loc == BloedLocatie.right_Ventricle)
        {
            setImagesInactive();
            dotHeart.enabled = true;
        }
        if (loc == BloedLocatie.right_Pulmonary_Artery)
        {
            setImagesInactive();
            dotLungsLeft.enabled = true;
        }
        if (loc == BloedLocatie.left_Pulmonary_Artery)
        {
            setImagesInactive();
            dotLungsRight.enabled = true;
        }
        if (loc == BloedLocatie.Brain)
        {
            //Debug.Log("Ik ben in de hersenen");
            setImagesInactive();
            dotHead.enabled = true;
        }
        if (loc == BloedLocatie.Stomach)
        {
            setImagesInactive();
            dotStomach.enabled = true;
        }
        if (loc == BloedLocatie.Liver)
        {
            setImagesInactive();
            dotLiver.enabled = true;
        }
        if (loc == BloedLocatie.left_Kidney)
        {
            setImagesInactive();
            dotKidneyLeft.enabled = true;
        }
        if (loc == BloedLocatie.right_Kidney)
        {
            setImagesInactive();
            dotKindeyRight.enabled = true;
        }
        if (loc == BloedLocatie.Pulmonary_Artery || loc == BloedLocatie.Pulmonary_Vein)
        {
            setImagesInactive();
            dotHeartLung.enabled = true;
        }
        if (loc == BloedLocatie.Common_Carotid_Artery || loc == BloedLocatie.Common_Carotid_Vein)
        {
            setImagesInactive();
            dotHeartHead.enabled = true;
        }
        if (loc == BloedLocatie.Gastric_Artery || loc == BloedLocatie.Gastric_Vein)
        {
            setImagesInactive();
            dotHeartStomach.enabled = true;
        }
        if (loc == BloedLocatie.Hepatic_Artery || loc == BloedLocatie.Hepatic_Vein)
        {
            setImagesInactive();
            dotHeartLiver.enabled = true;
        }
        if (loc == BloedLocatie.Inferior_Mesenteric_Artery)
        {
            setImagesInactive();
            dotHeartIntestines.enabled = true;
        }
        if (loc == BloedLocatie.Renal_Artery || loc == BloedLocatie.Renal_Veins)
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
