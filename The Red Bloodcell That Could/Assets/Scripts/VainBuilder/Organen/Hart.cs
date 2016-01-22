using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.Organen
{
    public class HartR : Orgaan
    {
        public HartR()
            : base()
        {
            this.scale = 4f;
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


            Debug.Log(position - origin);

            // Return the information in the VainDrawer format
            return new VainDrawer(position, rotation);
        }

        public override bool DrawMe(Transform parent, VainDrawer drawinfo)
        {
            this.scale = 4f;
            return base.DrawMe(parent, drawinfo);
        }
    }

    public class HartL : Orgaan
    {
        public HartL()
            : base()
        {
            this.scale = 4f;
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


            Debug.Log(position - origin);

            // Return the information in the VainDrawer format
            return new VainDrawer(position, rotation);
        }

        public override bool DrawMe(Transform parent, VainDrawer drawinfo)
        {
            this.scale = 4f;
            return base.DrawMe(parent, drawinfo);
        }
    }
}
