using Assets.Scripts.VainBuilder.OBJPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.Organen
{
    public class Orgaan : Vain
    {
        private float zuurstof = 0;

        protected Orgaan()
            : base()
        {
            this.exits = new Vain[2];
            //this.size = new Vector3(1, 1, 3);
            this.size = new UnityEngine.Vector3(1f, 1f, 40.5f);
            zuurstof = 1f;
        }

        public static Vain GetOrgaan(string data)
        {
            data = data.Replace("\r", "");
            string[] d = data.Split(new char[] { ';' }, StringSplitOptions.None);

            Orgaan organ = null;

            switch (d[2])
            {
                case "hartr":
                    organ = new HartR();
                    break;
                case "hartl":
                    organ = new HartL();
                    break;
                case "hersenen":
                    organ = new Hersenen();
                    break;
                case "longr":
                    organ = new LongR();
                    break;
                case "longl":
                    organ = new LongL();
                    break;
                case "lever":
                    organ = new Lever();
                    break;
                case "maag":
                    organ = new Maag();
                    break;
                case "darm":
                    organ = new Darmen();
                    break;
                case "nierl":
                case "nierr":
                    organ = new Nier();
                    break;
            }

            organ.SetID(Convert.ToInt32(d[1]));
            organ.SetScale(1f);

            return organ;
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
            Vector3 position = this.obj.transform.position;

            if (next == exits[1])
            {
                // Leave through bottom
                position += new Vector3(0, 0, size.z);
            }
            else
            {
                // Leave through top
                position += new Vector3(0, 0, size.z);
            }

            return new VainDrawer(position, new Vector3());
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

        public override bool DrawMe(Transform parent, VainDrawer drawinfo)
        {
            // Check if the vain is already drawn. If it is drawn already, skip creating the object
            if (!isDrawn)
            {
                // Get the next available object from the object pool
                //this.obj = ObjectPool.GetInstance().GetObject(this.GetType());
                this.obj = ObjectPool.INSTANCE.GetNext(this.GetType());
                this.obj.SetActive(true);

                // Set the parent of the object to the VainBuilder
                this.obj.transform.parent = parent;

                this.obj.name = this.id.ToString();

                // Set the scale of the object
                this.obj.transform.localScale = new Vector3(this.scale, this.scale, this.scale);

                //// Set the flip of the object
                //for (int i = 0; i < this.obj.transform.childCount; i++)
                //{
                //    this.obj.transform.GetChild(i).eulerAngles = new Vector3(0, 0, 0);
                //}

                // Remember that the vain is now drawn
                this.isDrawn = true;

                // Set the position and rotation of the vain
                if (!drawinfo.IsEmpty())
                    this.SetPosition(drawinfo);
            }

            // Return true if the vain has a second exit
            return this.HasSecondExit();
        }

        public void AddZuurstof(float value)
        {
            this.zuurstof += value;
            if (this.zuurstof > 1)
            {
                zuurstof = 1;
            }
        }

        public void RemoveZuurstof(float value)
        {
            this.zuurstof -= value;
            if (this.zuurstof < 0)
            {
                zuurstof = 0;
            }
        }

        public float GetZuurstof()
        {
            return this.zuurstof;
        }
    }
}
