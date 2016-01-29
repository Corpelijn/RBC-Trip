using UnityEngine;
using System.Collections;
using Assets.Scripts.VainBuilder;
using Assets.Scripts.VainBuilder.Organen;

public class betterColorChanger : MonoBehaviour
{

    public ParticleSystem oxygen;
    public AudioSource bubbles;
    public GameObject cel;
    private GameObject organ;

    public float celTimer;

    private const float DOWN_SPEED = 0.0001f;
    private const float UP_SPEED = 0.01f;

    public static betterColorChanger Instance { private set; get; }

    // Use this for initialization
    void Start()
    {
        Instance = this;
        celTimer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        organ = Assets.Scripts.Player.Instance.currentVain;

        // Action States
        // 0 = geen
        // 1 = oplopend
        // 2 = aflopend

        if (organ != null)
        {
            Vain v = VainBuilder.Instance.GetVain(organ);
            if (v.GetType().IsSubclassOf(typeof(Orgaan)))
            {
                Orgaan o = (Orgaan)v;
                int action = 0;

                if (o.GetType() == typeof(HartL) || o.GetType() == typeof(HartR)) { action = 0; }
                else if (o.GetType() == typeof(LongR) || o.GetType() == typeof(LongL)) { action = 1; }
                else { action = 2; }

                if (action == 1 && organ.transform.localScale.x == 0.25f)
                {
                    // Zuurstof oplopend
                    celTimer += UP_SPEED * 2f;
                }

                else if (action == 2 && organ.transform.localScale.x == 0.25f)
                {
                    // Zuurstof aflopend
                    celTimer -= 0.05f;
                    if (!oxygen.isPlaying)
                    {
                        oxygen.Play();
                        bubbles.Play();
                    }
                    if (celTimer < 0)
                    {
                        celTimer = 0;
                        oxygen.Stop();
                        o.AddZuurstof(UP_SPEED);
                    }                                        
                }

                //Debug.Log(celTimer);
            }
        }

        for (int i = -1; i > -11; i--)
        {
            Orgaan o = (Orgaan)VainBuilder.Instance.GetVain(i);
            o.RemoveZuurstof(DOWN_SPEED);
            //Debug.Log(o.GetType().Name + ": " + o.GetZuurstof());
        }
    }
}
