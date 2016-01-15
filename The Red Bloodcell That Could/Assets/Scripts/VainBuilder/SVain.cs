﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    class SVain : Vain
    {
        /**
         *      | 1 |
         *      |   |
         *      |   |
         *      |   |
         *      | 0 |
         */

        public SVain()
            : base()
        {
            this.exits = new Vain[2];
            this.size = new Vector3(1, 1, 3);
        }

        public override Vain GetStraight(Vain last)
        {
            if (exits[0] == last)
                return exits[1];
            else
                return exits[0];
        }

        public override VainDrawer CalculateNextPosition(Vain last, Vain next)
        {
            // Define some variables
            Vector3 position = this.obj.transform.position;
            Vector3 rotation = this.obj.transform.eulerAngles;

            // Check in what direction the vain is placed
            bool flip = this.obj.transform.GetChild(0).transform.forward.z != -1f;
            Vector3 origin = this.obj.transform.position;
            Vector3 far = origin + new Vector3(0f, 0f, this.obj.GetComponentInChildren<MeshFilter>().mesh.bounds.extents.z * 2) * scale;

            Vector3 exit0 = flip ? far : origin;
            Vector3 exit1 = flip ? origin : far;

            //Debug.Log(this.GetID() + " : e0 " + exit0 + " : e1 " + exit1);

            // Check from wich end we are leaving
            if (next == exits[0])
            {
                // We are leaving from the bottom side
                // Set the position to continue on bottom and set the exit position to a calculation from the current vain
                //position = new Vector3(position.x, position.y, position.z - (size.z * this.scale));
                position = exit0;
            }
            else
            {
                // We are leaving from the top side
                // Set the position to continue on top and set the exit position to a calculation from the current vain
                //position = new Vector3(position.x, position.y, position.z + (size.z * this.scale));
                position = exit1;
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
            return false;
        }
    }
}
