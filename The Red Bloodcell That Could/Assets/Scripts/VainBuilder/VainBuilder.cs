using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.VainBuilder
{
    public class VainBuilder : MonoBehaviour
    {
        public TextAsset vainData;
        private List<VainExit> exits;
        private List<Vain> vains;

        private Vain[] lastVains;

        public void Start()
        {
            exits = new List<VainExit>();
            vains = new List<Vain>();

            // Quickly read the data from the file and put it in some classes for later
            string[] lines = vainData.text.Split(new string[] {"\n"}, System.StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("e"))
                    exits.Add(new VainExit(lines[i]));
                else if (lines[i].StartsWith("v"))
                    vains.Add(Vain.GetVain(lines[i]));
            }

            // Read the classes and put them together
            foreach (VainExit ve in exits)
            {
                Vain vain1 = GetVain(ve.Vain1);
                Vain vain2 = GetVain(ve.Vain2);
                if (vain1 == null || vain2 == null)
                {
                    Debug.Log("Vain not found");
                    continue;
                }

                vain1.SetExit(ve.Vain1Exit, vain2);
                vain2.SetExit(ve.Vain2Exit, vain1);
            }

            if (vains.Count > 0)
            {
                vains[0].DrawMe(this.transform);
                lastVains = new Vain[]{vains[0]};
            }
        }

        public void Update()
        {
            
        }

        private Vain GetVain(int id)
        {
            foreach (Vain v in vains)
            {
                if (v.ID == id)
                {
                    return v;
                }
            }

            return null;
        }
    }
}
