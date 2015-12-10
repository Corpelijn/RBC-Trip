using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.VainBuilder
{
    class SVain : Vain
    {
        public SVain()
            : base()
        {
            this.exits = new Vain[2];
        }

        public override Vain[] DrawNext(Vain ingang, UnityEngine.Transform parent)
        {
            if (ingang == null)
            {
                return null;
            }

            // Komt aan vanaf de onderkant (enkele ingang/uitgang)
            if (ingang == exits[0])
            {
                exits[1].DrawMe(parent);
                exits[1].UpdatePosition(this.obj.transform, new Vector3(0, 0, 3), new Vector3(), exits[1]);
            }
            // Komt aan vanaf de bovenkant
            else if(ingang == exits[1])
            {
                exits[0].DrawMe(parent);
                exits[0].UpdatePosition(this.obj.transform, new Vector3(0, 0, -3), new Vector3(), exits[0]);
            }

            return base.DrawNext(ingang, parent);
        }
    }
}
