using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    class TVain : Vain
    {
        public TVain()
            : base()
        {
            this.exits = new Vain[2];
        }

        public override Vain GetStraight()
        {
            // Find the end of the vain that is already drawn
            int found = -1;
            for (int i = 0; i < exits.Length; i++)
            {
                if (exits[i] == null)
                    continue;
                if (exits[i].IsDrawn())
                {
                    // You found the vain that is drawn at the moment
                    // End your quest
                    found = i;
                    break;
                }
            }

            // Return the opposite exit of the found one
            if (found == 0)
            {
                // Return the opposite exit from the 0-exit
                return this.exits[1];
            }
            else if (found == 1)
            {
                // Return the opposite exit from the 1-exit
                return this.exits[0];
            }
            else
            {
                // There is no vain found that had to be drawn
                // This could mean that it is the first vain we are trying to draw
                // Return by default the exit that is not null
                return this.exits[0] == null ? this.exits[1] : this.exits[0];
            }
        }

        public override VainDrawer CalculateNextPosition()
        {
            // Get the vain we are moving towards
            Vain v = GetStraight();

            // Define some variables
            Vector3 position = this.obj.transform.position;
            Vector3 rotation = this.obj.transform.eulerAngles;
            Vector3 exit_pos = new Vector3();
            Vector3 exit_rot = new Vector3();

            // Check from wich end we are leaving
            if (v == exits[0])
            {
                // We are leaving from the top side
                // Set the position to continue on top and set the exit position to a calculation from the current vain
                rotation = new Vector3(rotation.x, rotation.y + 30.0f, rotation.z);
                exit_pos = new Vector3(position.x + 0.7f, position.y, position.z + 1.25f);
                Vector3 delta = exit_pos - position;
                position = new Vector3(position.x + delta.x, position.y + delta.y, position.z + delta.z);
            }
            else
            {
                // We are leaving from the top side
                // Set the position to continue on top and set the exit position to a calculation from the current vain
                rotation = new Vector3(rotation.x, rotation.y + 30.0f, rotation.z);
                exit_rot = rotation;
                float a = (Mathf.Sin(rad(30)) * 2.75f) / Mathf.Sin(rad(90));
                float c = (Mathf.Sin(rad(60)) * 2.75f) / Mathf.Sin(rad(90));
                exit_pos = new Vector3(position.x + a, position.y, position.z + c);
                position = new Vector3(position.x + a * 2, position.y, position.z + c * 2);
            }

            // Return the information in the VainDrawer format
            return new VainDrawer(exit_pos, exit_rot);
        }

        private float rad(float angle)
        {
            return (Mathf.PI / 180) * angle;
        }
    }
}
