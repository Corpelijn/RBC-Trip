﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    class EVain : Vain
    {
        public EVain()
            : base()
        {
            this.exits = new Vain[3];
            this.size = new Vector3(1.75f, 1, 3);
        }

        public override Vain GetStraight(Vain last)
        {
            // Return the opposite exit of the found one
            if (exits[0] == last)
            {
                // Return the opposite exit from the 0-exit
                return this.exits[1];
            }
            else if (exits[1] == last || exits[2] == last)
            {
                // Return the opposite exit from the 1-exit or 2-exit
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

        public override VainDrawer CalculateNextPosition(Vain last, Vain next)
        {
            // Get the vain we are moving towards
            //Vain v = GetStraight(last);

            // Define some variables
            Vector3 position = this.obj.transform.position;
            Vector3 rotation = this.obj.transform.eulerAngles;

            // Check from wich end we are leaving
            if (next == exits[0])
            {
                // We are leaving from the bottom side
                // Set the position to continue on bottom and set the exit position to a calculation from the current vain
                position = new Vector3(position.x, position.y, position.z - (size.z * this.scale));
            }
            else if(next == exits[1])
            {
                // We are leaving from the top side
                // Set the position to continue on top and set the exit position to a calculation from the current vain
                position = new Vector3(position.x, position.y, position.z + (size.z * this.scale));
            }
            else
            {
                // We are leaving from the small top side
                // Set the position to continue on small top and set the exit position to a calculation from the current vain
                position = new Vector3(position.x - (1.0525f * this.scale), position.y, position.z + (size.z * this.scale));
            }

            // Return the information in the VainDrawer format
            return new VainDrawer(position, rotation);
        }

        protected override void SetPosition(VainDrawer drawinfo)
        {
            // Apply the rotation before calculations
            this.obj.transform.eulerAngles = drawinfo.ExitRotation;
            this.obj.transform.position = drawinfo.ExitPosition;

            // Caculate the centerpoint of the of this vain
            Vector3 VainExit = new Vector3();
            if (drawinfo.DestinationExit == 0)
            {
                VainExit = new Vector3(this.obj.transform.position.x, this.obj.transform.position.y, this.obj.transform.position.z);
            }
            else if (drawinfo.DestinationExit == 1)
            {
                VainExit = new Vector3(this.obj.transform.position.x, this.obj.transform.position.y, this.obj.transform.position.z + (size.z * this.scale));
            }

            // Check if there is a differance between the 2 coordinates
            Vector3 delta = drawinfo.ExitPosition - VainExit;
            if (delta.x == 0 && delta.y == 0 && delta.z == 0)
            {
                // Apply the new position to the vain
                this.obj.transform.position = VainExit;
            }
            else
            {
                this.obj.transform.position = drawinfo.ExitPosition + delta;
            }
        }

        public override bool HasSecondExit()
        {
            return true;
        }

        public override Vain GetSecond(Vain last)
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
                return this.exits[2];
            }
            else if (found == 1)
            {
                // Return the opposite exit from the 1-exit
                return this.exits[2];
            }
            else if (found == 2)
            {
                // Return the opposite exit from the 2-exit
                return this.exits[1];
            }
            else
            {
                // There is no vain found that had to be drawn
                // This could mean that it is the first vain we are trying to draw
                // Return by default the exit that is not null
                return this.exits[0] == null ? this.exits[1] : this.exits[0];
            }
        }
    }
}
