using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.Organen
{
    class Orgaan : Vain
    {
        public Orgaan()
            : base()
        {
            this.exits = new Vain[2];
            this.size = new Vector3(1, 1, 3);
        }

        public static Vain GetOrgaan(string data)
        {
            data = data.Replace("\r", "");
            string[] d = data.Split(new char[] { ';' }, StringSplitOptions.None);

            Vain vain = new Orgaan();

            vain.SetID(Convert.ToInt32(d[1]));
            vain.SetScale(4f);

            return vain;
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
            else
            {
                // We are leaving from the top side
                // Set the position to continue on top and set the exit position to a calculation from the current vain
                position = new Vector3(position.x, position.y, position.z + (size.z * this.scale));
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
