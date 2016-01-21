using UnityEngine;
using System.Collections;
using Assets.Scripts.VainBuilder;
using Assets.Scripts.VainBuilder.Organen;

public class betterColorChanger : MonoBehaviour
{

    public GameObject cel;
    private GameObject organ;

    private float celTimer;

    // Use this for initialization
    void Start()
    {
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
            if (!v.GetType().IsSubclassOf(typeof(Orgaan)))
            { return; }
            Orgaan o = (Orgaan)v;
            int action = 0;

            if (o.GetType() == typeof(Hart)) { action = 0; }
            else if (o.GetType() == typeof(Long)) { action = 1; }
            else { action = 2; }

            if (action == 1 && organ.transform.localScale.x == 0.25f)
            {
                // Zuurstof oplopend
                celTimer += 0.1f;
            }
            else if (action == 2 && organ.transform.localScale.x == 0.25f)
            {
                // Zuurstof aflopend
                celTimer -= 0.1f;
                o.AddZuurstof(0.1f);
            }

            o.RemoveZuurstof(0.01f);
        }
    }
}
