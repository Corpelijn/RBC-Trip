using Assets.Scripts.MapGeneration.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    class YVain : Vain
    {
        /**     1   2
         *      \   /
         *       \ /
         *        |
         *        |
         *        0
         */


        public YVain()
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
            // Define some variables
            Vector3 position = this.obj.transform.position;
            Vector3 rotation = this.obj.transform.eulerAngles;

            // Check in what direction the vain is placed
            bool flip = this.obj.transform.GetChild(0).transform.forward.z != -1f;
            Vector3 origin = this.obj.transform.position;
            Vector3 far = origin + new Vector3(0f, 0f, this.obj.GetComponentInChildren<MeshFilter>().mesh.bounds.extents.z * 2);

            Vector3 exit0 = flip ? (far + new Vector3(0f, 0f, size.z * this.scale)) : origin;
            Vector3 exit1 = (flip ? origin : far) + new Vector3(-0.574f, 0f, 0f);
            Vector3 exit2 = (flip ? origin : far) + new Vector3(0.574f, 0f, 0f);

            Debug.Log("0 : " + exit0);
            Debug.Log("1 : " + exit1);
            Debug.Log("2 : " + exit2);

            // Check from wich end we are leaving
            if (next == exits[0])
            {
                // We are leaving from the bottom side
                // Set the position to continue on bottom and set the exit position to a calculation from the current vain
                //if (direction.z == -1f)
                //{
                //    position = new Vector3(position.x, position.y, position.z + (size.z * this.scale));
                //}
                //else
                //{
                //    position = new Vector3(position.x, position.y, position.z);
                //}
                position = exit0;
            }
            else if(next == exits[1])
            {
                // We are leaving from the left top side
                // Set the position to continue on left top and set the exit position to a calculation from the current vain
                //if (direction.z == -1f)
                //{
                //    position = new Vector3(position.x - (0.574f * this.scale), position.y, position.z + (size.z * this.scale));
                //}
                //else
                //{
                //    position = new Vector3(position.x + (0.574f * this.scale), position.y, position.z);
                //}
                position = exit1;
            }
            else
            {
                // We are leaving from the right top side
                // Set the position to continue on right top and set the exit position to a calculation from the current vain
                //if (direction.z == -1f)
                //{
                //    position = new Vector3(position.x + (0.574f * this.scale), position.y, position.z + (size.z * this.scale));
                //}
                //else
                //{
                //    position = new Vector3(position.x - (0.574f * this.scale), position.y, position.z);
                //}
                position = exit2;
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
                VainExit = new Vector3(this.obj.transform.position.x - (0.574f * this.scale), this.obj.transform.position.y, this.obj.transform.position.z);
            }
            else
            {
                VainExit = new Vector3(this.obj.transform.position.x + (0.574f * this.scale), this.obj.transform.position.y, this.obj.transform.position.z);
            }

            // Check if there is a differance between the 2 coordinates
            Vector3 delta = drawinfo.ExitPosition - VainExit;
            delta.x = Mathf.Abs(delta.x);
            delta.y = Mathf.Abs(delta.y);
            delta.z = Mathf.Abs(delta.z);
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
