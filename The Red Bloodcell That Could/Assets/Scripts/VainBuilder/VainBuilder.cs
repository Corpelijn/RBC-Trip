using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.VainBuilder
{
    public class VainBuilder : MonoBehaviour
    {
        public TextAsset vainData;
        private List<VainExit> exits;
        private List<Vain> vains;

        public int renderAmount = 5;

        public static VainBuilder Instance { get; private set; }
        private List<Vain> visible;

        private void Start()
        {
            Instance = this;
            exits = new List<VainExit>();
            vains = new List<Vain>();
            visible = new List<Vain>();

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
                //vains[0].DrawMe(this.transform);
                visible.Add(vains[0]);
            }
        }

        private void Update()
        {
            // Check what vains need to be drawn
            Vain currentVain = GetVain(Player.Instance.currentVain);
            visible.Add(currentVain);

            Vain lastVain = null;
            VainDrawer nextPosition = new VainDrawer();
            for (int i = 0; i < renderAmount; i++)
            {
                try
                {
                    Debug.Log(i + ":" + lastVain);
                    Vain newVain = currentVain.GetStraight(lastVain);
                    lastVain = currentVain;
                    currentVain = newVain;
                    if (currentVain != null)
                    {
                        currentVain.DrawMe(this.transform);
                        currentVain.SetTransform(nextPosition);
                        visible.Add(currentVain);

                        nextPosition = currentVain.CalculateNextPosition();
                    }
                }
                catch (Exception ex)
                {
                    Debug.Log(i);
                }
            }

            visible.Clear();
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

        private Vain GetVain(GameObject obj)
        {
            foreach (Vain v in vains)
            {
                if (v.GameObject == obj)
                {
                    return v;
                }
            }

            return null;
        }

        public Vain GetNext(Vain previous, Vain current)
        {
            int exit = current.GetNext(previous);
            if (exit == -1)
                return null;
            return current.GetExit(exit);
        }
    }
}
