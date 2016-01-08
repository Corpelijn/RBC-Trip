using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.VainBuilder
{
    public class VainBuilder : MonoBehaviour
    {
        public List<TextAsset> vainData;
        private List<VainExit> exits;
        private List<Vain> vains;

        public int renderDistance = 5;

        public static VainBuilder Instance { get; private set; }
        private List<Vain> visible;

        private Vain currentPlayerVain = null;
        private Vain lastPlayerVain = null;

        private void Start()
        {
            Instance = this;
            exits = new List<VainExit>();
            vains = new List<Vain>();
            visible = new List<Vain>();

            // Quickly read the data from the file and put it in some classes for later
            foreach (TextAsset info in vainData)
            {
                string[] lines = info.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("e"))
                        exits.Add(new VainExit(lines[i]));
                    else if (lines[i].StartsWith("v"))
                        vains.Add(Vain.GetVain(lines[i]));
                    else if (lines[i].StartsWith("o"))
                        vains.Add(Organen.Orgaan.GetOrgaan(lines[i]));
                }
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
        }

        private void Update()
        {
            // Check if there is any vain drawn ever
            if (visible.Count == 0)
            {
                // There are no vains drawn yet. 
                // Draw the first vain in the list if there is one
                if (vains.Count > 0)
                {
                    // Draw the vain
                    vains[0].DrawMe(this.transform, new VainDrawer());

                    // Set the vain as the last vain
                    currentPlayerVain = vains[0];
                    lastPlayerVain = vains[0].GetExit(0);

                    // Add the vain to the visible object
                    visible.Add(vains[0]);


                    // Return the method. We do not want to draw anything else at the moment
                    return;
                }
            }
            else
            {
                // If the last vain is already set, set it to the current vain of the player
                Vain cv = GetVain(Player.Instance.currentVain);
                if (cv == null)
                    return;

                if (cv != currentPlayerVain)
                {
                    lastPlayerVain = currentPlayerVain;
                    currentPlayerVain = cv;
                }
            }

            List<Vain> currentVains = new List<Vain>(new Vain[] { currentPlayerVain });
            List<Vain> lastVains = new List<Vain>(new Vain[] { lastPlayerVain });

            // Continue here to see if there are more vains needed to be drawn
            for (int i = 0; i < renderDistance; i++)
            {
                List<Vain> newCurrents = new List<Vain>();
                for (int j = 0; j < currentVains.Count; j++)
                {
                    Vain currentVain = currentVains[j];
                    Vain lastVain = lastVains.Count == currentVains.Count ? lastVains[j] : lastVains[0];

                    // Get the next vain
                    Vain next = currentVain.GetStraight(lastVain);

                    // Check if the vain is not empty
                    if (next == null)
                        continue;

                    // Get the information where the next object should be drawed
                    VainDrawer drawinfo = currentVain.CalculateNextPosition(lastVain, next);

                    // Get the exit to wich the last vain was connected
                    int exit = next.GetExit(currentVain);

                    // Check if the exit id not equals -1
                    if (exit == -1)
                    {
                        throw new Exception("Seriously?!?! How did you manage to trigger this exception?!?!");
                    }

                    // Put the information into the drawinformation
                    drawinfo.DestinationExit = exit;

                    // Draw the next vain
                    next.DrawMe(this.transform, drawinfo);

                    next.AddDrawcall();

                    // Add the vain to the visible object
                    if (!visible.Contains(next))
                        visible.Add(next);

                    // Add the next vain to the new current list
                    newCurrents.Add(next);

                    // Check if a second vain needs to be drawn
                    if (currentVain.HasSecondExit())
                    {
                        // Get the second vain
                        next = currentVain.GetSecond(lastVain);

                        // Check if the vain is not empty
                        if (next == null)
                            continue;

                        // Get the information where the next object should be drawed
                        drawinfo = currentVain.CalculateNextPosition(lastVain, next);

                        // Get the exit to wich the last vain was connected
                        exit = next.GetExit(currentVain);

                        // Check if the exit id not equals -1
                        if (exit == -1)
                        {
                            throw new Exception("Seriously?!?! How did you manage to trigger this exception?!?!");
                        }

                        // Put the information into the drawinformation
                        drawinfo.DestinationExit = exit;

                        // Draw the next vain
                        next.DrawMe(this.transform, drawinfo);

                        next.AddDrawcall();

                        // Add the vain to the visible object
                        if (!visible.Contains(next))
                            visible.Add(next);

                        // Add the next vain to the new current list
                        newCurrents.Add(next);
                    }
                }

                // Set the next vain as the last
                lastVains = currentVains;
                currentVains = newCurrents;
                //lastVain = currentVain;
                //currentVain = next;
            }

            // Check if there are items that can be removed
            int index = 0;
            while (index < visible.Count)
            {
                if (visible[index].HasDrawcalls())
                {
                    visible[index].RemoveDrawcall();
                }
                else
                {
                    if (visible[index] == lastPlayerVain || visible[index] == currentPlayerVain)
                    {
                        index++;
                        continue;
                    }
                    visible[index].DestroyMe();
                    visible.RemoveAt(index);
                    continue;
                }
                index++;
            }
        }

        private Vain GetVain(int id)
        {
            foreach (Vain v in vains)
            {
                if (v.GetID() == id)
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
                if (v.GetGameObject() == obj)
                {
                    return v;
                }
            }

            return null;
        }
    }
}
