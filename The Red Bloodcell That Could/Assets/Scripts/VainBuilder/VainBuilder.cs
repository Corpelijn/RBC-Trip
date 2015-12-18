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

        public int renderDistance = 5;

        public static VainBuilder Instance { get; private set; }
        private List<Vain> visible;
        private Vain lastVain = null;

        private void Start()
        {
            Instance = this;
            exits = new List<VainExit>();
            vains = new List<Vain>();
            visible = new List<Vain>();

            // Quickly read the data from the file and put it in some classes for later
            string[] lines = vainData.text.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
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
                    lastVain = vains[0];

                    // Add the vain to the visible object
                    visible.Add(vains[0]);

                    // Return the method. We do not want to draw anything else at the moment
                    return;
                }
            }
            else
            {
                // If the last vain is already set, set it to the current vain of the player
                lastVain = GetVain(Player.Instance.currentVain);
                if (lastVain == null)
                    return;
            }

            Vain previous = null;

            // Continue here to see if there are more vains needed to be drawn
            for (int i = 0; i < renderDistance; i++)
            {
                // Get the next vain
                Vain next = lastVain.GetStraight(previous);

                // Check if the vain is not empty
                if (next == null)
                    continue;

                // Get the information where the next object should be drawed
                VainDrawer drawinfo = lastVain.CalculateNextPosition(previous);
                
                // Get the exit to wich the last vain was connected
                int exit = next.GetExit(lastVain);

                // Check if the exit id not equals -1
                if (exit == -1)
                {
                    throw new Exception("Seriously?!?! How did you manage to trigger this exception?!?!");
                }

                // Put the information into the drawinformation
                drawinfo.DestinationExit = exit;

                // Draw the next vain
                next.DrawMe(this.transform, drawinfo);

                // Add the vain to the visible object
                if (!visible.Contains(next))
                    visible.Add(next);

                // Set the next vain as the last
                lastVain = next;
            }

            // Check if there are items that can be removed
            // :TODO: !!
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
