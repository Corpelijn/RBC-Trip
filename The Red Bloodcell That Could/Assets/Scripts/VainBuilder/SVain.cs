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

        public override GameObject DrawMe(Transform parent, GameObject previous)
        {
            GameObject go = DrawMe(parent);
            

            if (previous != null)
            {
                Transform prev = previous.transform;
                go.transform.position = new Vector3(prev.position.x, prev.position.y, prev.position.z + 3);
            }
            
            return go;
        }

        public override Vain GetStraight(Vain previous)
        {
            if (previous == null)
                return this.exits[1];
            return base.GetStraight(previous);
        }

        public override VainDrawer CalculateNextPosition()
        {
            Vector3 position = new Vector3(this.obj.transform.position.x, this.obj.transform.position.y, this.obj.transform.position.z + 3);
            Vector3 rotation = new Vector3();
            Vector3 exit = new Vector3(0, 0, 0);

            return new VainDrawer(position, rotation, exit);
        }
    }
}
