using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.Organen
{
    public class Hersenen : Orgaan
    {
        public Hersenen()
            : base()
        {
            //this.size = new UnityEngine.Vector3(1.0f, 1.0f, 16.5f);
        }

        //public override VainDrawer CalculateNextPosition(Vain last, Vain next)
        //{
        //    Vector3 position = this.obj.transform.position;

        //    if(next == exits[1])
        //    {
        //        // Leave through bottom
        //        position += new Vector3(0, 0, size.z);
        //    }
        //    else
        //    {
        //        // Leave through top
        //        position += new Vector3(0, 0, size.z);
        //    }

        //    return new VainDrawer(position, new Vector3());
        //}

        //public override bool DrawMe(Transform parent, VainDrawer drawinfo)
        //{
        //    bool result = base.DrawMe(parent, drawinfo);

        //    this.obj.transform.GetChild(0).eulerAngles = new Vector3();

        //    return result;
        //}
    }
}
