using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder.Organen
{
    public class Darmen : Orgaan
    {
        public Darmen()
            : base()
        {
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
    }
}
